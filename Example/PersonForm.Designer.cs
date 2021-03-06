﻿namespace Example
{
    partial class PersonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FirstNameInput = new System.Windows.Forms.TextBox();
            this.LastNameInput = new System.Windows.Forms.TextBox();
            this.AgeInput = new System.Windows.Forms.ComboBox();
            this.SayHelloCmdButton = new Rubberduck.Winforms.CommandButton();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstNameInput
            // 
            this.FirstNameInput.Location = new System.Drawing.Point(87, 87);
            this.FirstNameInput.Name = "FirstNameInput";
            this.FirstNameInput.Size = new System.Drawing.Size(100, 20);
            this.FirstNameInput.TabIndex = 1;
            // 
            // LastNameInput
            // 
            this.LastNameInput.Location = new System.Drawing.Point(87, 146);
            this.LastNameInput.Name = "LastNameInput";
            this.LastNameInput.Size = new System.Drawing.Size(100, 20);
            this.LastNameInput.TabIndex = 3;
            // 
            // AgeInput
            // 
            this.AgeInput.FormattingEnabled = true;
            this.AgeInput.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.AgeInput.Location = new System.Drawing.Point(87, 197);
            this.AgeInput.Name = "AgeInput";
            this.AgeInput.Size = new System.Drawing.Size(121, 21);
            this.AgeInput.TabIndex = 4;
            // 
            // SayHelloCmdButton
            // 
            this.SayHelloCmdButton.Command = null;
            this.SayHelloCmdButton.CommandParameter = null;
            this.SayHelloCmdButton.Enabled = false;
            this.SayHelloCmdButton.Location = new System.Drawing.Point(337, 307);
            this.SayHelloCmdButton.Name = "SayHelloCmdButton";
            this.SayHelloCmdButton.Size = new System.Drawing.Size(75, 23);
            this.SayHelloCmdButton.TabIndex = 5;
            this.SayHelloCmdButton.Text = "Say Hello";
            this.SayHelloCmdButton.UseVisualStyleBackColor = true;
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataSource = typeof(Example.Person);
            // 
            // PersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(505, 435);
            this.Controls.Add(this.SayHelloCmdButton);
            this.Controls.Add(this.AgeInput);
            this.Controls.Add(this.LastNameInput);
            this.Controls.Add(this.FirstNameInput);
            this.Name = "PersonForm";
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstNameInput;
        private System.Windows.Forms.TextBox LastNameInput;
        private System.Windows.Forms.ComboBox AgeInput;
        private Rubberduck.Winforms.CommandButton SayHelloCmdButton;
        private System.Windows.Forms.BindingSource personBindingSource;
    }
}
