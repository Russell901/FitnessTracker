namespace FitnessTracker.Views
{
    partial class LoginForm
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
            passwordTextBox = new TextBox();
            usernameTextBox = new TextBox();
            label1 = new Label();
            showPasswordCheckBox = new CheckBox();
            label2 = new Label();
            loginButton = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(235, 209);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(230, 23);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.Click += loginButton_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(235, 127);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(230, 23);
            usernameTextBox.TabIndex = 2;
            usernameTextBox.Click += loginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(235, 191);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Password";
            label1.Click += loginButton_Click;
            // 
            // showPasswordCheckBox
            // 
            showPasswordCheckBox.AutoSize = true;
            showPasswordCheckBox.Location = new Point(471, 211);
            showPasswordCheckBox.Name = "showPasswordCheckBox";
            showPasswordCheckBox.Size = new Size(107, 19);
            showPasswordCheckBox.TabIndex = 5;
            showPasswordCheckBox.Text = "show password";
            showPasswordCheckBox.UseVisualStyleBackColor = true;
            showPasswordCheckBox.CheckedChanged += ShowPasswordCheckBox_CheckedChanged;
            showPasswordCheckBox.Click += loginButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 109);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 6;
            label2.Text = "Username";
            label2.Click += loginButton_Click;
            // 
            // loginButton
            // 
            loginButton.BackColor = SystemColors.Highlight;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.ForeColor = SystemColors.HighlightText;
            loginButton.Location = new Point(290, 273);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(147, 35);
            loginButton.TabIndex = 7;
            loginButton.Text = "Log in";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(360, 370);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(77, 15);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Register Here";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabel1);
            Controls.Add(loginButton);
            Controls.Add(label2);
            Controls.Add(showPasswordCheckBox);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private Label label1;
        private CheckBox showPasswordCheckBox;
        private Label label2;
        private Button loginButton;
        private LinkLabel linkLabel1;
    }
}