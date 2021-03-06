﻿using System;
using Rubberduck.Winforms;

namespace Example
{
    public partial class PersonForm : ModelBoundForm
    {
        public event EventHandler Submit;

        public PersonForm()
            :base(model: new Person())
        {
            InitializeComponent();

            // Databind the Person.FirstName property to the FirstNameInput textbox
            FirstNameInput.DataBindings.Add(new TextBinding(this.Model, "FirstName"));
            Register(Label.For(FirstNameInput));
            Register(ErrorLabel.For(FirstNameInput));

            LastNameInput.DataBindings.Add(new TextBinding(this.Model, "LastName"));
            Register(Label.For(LastNameInput));
            Register(ErrorLabel.For(LastNameInput));

            //Works with ComboBoxes too!
            AgeInput.DataBindings.Add(new TextBinding(this.Model, "Age"));
            //Put the label to the right of the input control.
            Register(Label.For(AgeInput, Alignment.Right)); 
            //Put the validation message under the control, with a little extra padding.
            Register(ErrorLabel.For(AgeInput, Alignment.Bottom, ErrorLabel.DefaultPadding + 5));

            //Register HelloCommand
            
            this.SayHelloCmdButton.Command = new SayHelloCommand(this.Model as Person);
            this.SayHelloCmdButton.DataBindings.Add(new System.Windows.Forms.Binding("CommandParameter", this.LastNameInput, "Text"));
            //this.SayHelloCmdButton.CommandParameter = "Hola";
        }
    }
}
