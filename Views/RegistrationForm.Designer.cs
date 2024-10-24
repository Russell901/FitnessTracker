namespace FitnessTracker.Views
{
    partial class RegistrationForm
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
            registerButton = new Button();
            label2 = new Label();
            showPasswordCheckBox = new CheckBox();
            label1 = new Label();
            passwordTextBox = new TextBox();
            usernameTextBox = new TextBox();
            SuspendLayout();
            // 
            // registerButton
            // 
            registerButton.BackColor = SystemColors.Highlight;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.ForeColor = SystemColors.HighlightText;
            registerButton.Location = new Point(284, 290);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(147, 35);
            registerButton.TabIndex = 13;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += RegisterButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(229, 126);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 12;
            label2.Text = "Username";
            // 
            // showPasswordCheckBox
            // 
            showPasswordCheckBox.AutoSize = true;
            showPasswordCheckBox.Location = new Point(465, 228);
            showPasswordCheckBox.Name = "showPasswordCheckBox";
            showPasswordCheckBox.Size = new Size(107, 19);
            showPasswordCheckBox.TabIndex = 11;
            showPasswordCheckBox.Text = "show password";
            showPasswordCheckBox.UseVisualStyleBackColor = true;
            showPasswordCheckBox.CheckedChanged += ShowPasswordCheckBox_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(229, 208);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 10;
            label1.Text = "Password";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(229, 226);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(230, 23);
            passwordTextBox.TabIndex = 9;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(229, 144);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(230, 23);
            usernameTextBox.TabIndex = 8;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registerButton);
            Controls.Add(label2);
            Controls.Add(showPasswordCheckBox);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button registerButton;
        private Label label2;
        private CheckBox showPasswordCheckBox;
        private Label label1;
        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
    }
}