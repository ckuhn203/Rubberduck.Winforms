﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Rubberduck.Winforms.DataAnnotations
{
    public partial class ModelBoundForm : Form
    {
        public ModelBoundForm()
        {
            InitializeComponent();
        }

        public ModelBoundForm(Object model)
        {
            InitializeComponent();

            this.Model = model;
        }

        private readonly Dictionary<string, ErrorLabel> _errorLabels = new Dictionary<string, ErrorLabel>();
        private readonly Dictionary<string, Label> _labels = new Dictionary<string, Label>();

        /// <summary>
        /// The view model. It must implement INotifyPropertyChanged for validation to work correctly.
        /// </summary>
        public object Model { get; set; }

        protected void Register(ErrorLabel errorLabel)
        {
            _errorLabels.Add(errorLabel.Control.Name, errorLabel);
            Controls.Add(errorLabel);

            //todo: I don't care for this much. Add support for other types of input
            errorLabel.Control.Validating += (sender, args) => ValidateControl(errorLabel.Control, "Text");
        }

        protected void Register(Label label)
        {
            _labels.Add(label.Control.Name, label);
            Controls.Add(label);

            //todo: again, add support for other types of input
            var boundField = GetBoundField(label.Control, "Text");
                
            var attribute = this.Model.GetType()
                .GetProperty(boundField)
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault();

            label.Text = (attribute == null) ? boundField : ((DisplayAttribute) attribute).Name;
        }

        /// <summary>
        /// Validates the <paramref name="textBox"/>, displaying an <see cref="ErrorLabel"/> if the input is invalid.
        /// </summary>
        /// <param name="textBox">The control to be validated.</param>
        /// <returns>True if valid. False if invalid.</returns>
        protected bool ValidateTextBox(TextBox textBox)
        {
            return ValidateControl(textBox, "Text");
        }

        /// <summary>
        /// Validates the <paramref name="control"/>, displaying an <see cref="ErrorLabel"/> if the input is invalid.
        /// </summary>
        /// <param name="control">The control to be validated.</param>
        /// <param name="controlProperty">The name of the control property that is databound to the <see cref="Model"/>.</param>
        /// <returns>True if valid. False if invalid.</returns>
        protected bool ValidateControl(Control control, string controlProperty)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            ErrorLabel errorLabel;
            if (!_errorLabels.TryGetValue(control.Name, out errorLabel))
            {
                throw new InvalidOperationException("Unable to retrieve ErrorLabel for control " + control.Name);
            }

            string boundField = GetBoundField(control, controlProperty);
            var context = new ValidationContext(this.Model, null, null) { MemberName = boundField };

            object propertyValue = this.Model.GetType().InvokeMember(boundField, System.Reflection.BindingFlags.GetProperty, null, this.Model, null);

            var validationResults = new List<ValidationResult>();
            Validator.TryValidateProperty(propertyValue, context, validationResults);

            var validation = validationResults.FirstOrDefault();

            if (validation == null)
            {
                //Input is valid
                errorLabel.Text = String.Empty;
                return true;
            }

            errorLabel.Text = validation.ErrorMessage;
            return false;
        }

        private static string GetBoundField(Control control, string controlProperty)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            if (controlProperty == null)
            {
                throw new ArgumentNullException("controlProperty");
            }

            ControlBindingsCollection bindings = control.DataBindings;

            if (bindings.Count <= 0)
            {
                throw new InvalidOperationException("There are no bindings for " + control.Name + ".");
            }

            Binding binding = bindings[controlProperty];
            if (binding == null)
            {
                throw new ArgumentException("No binding was set for " + control.Name + "." + controlProperty, "controlProperty");
            }

            return binding.BindingMemberInfo.BindingField;
        }
    }
}
