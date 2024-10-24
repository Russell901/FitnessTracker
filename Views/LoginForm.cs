using FitnessTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTracker.Views
{
    public partial class LoginForm : Form
    {
        private readonly UserViewModel _viewModel;

        public LoginForm(UserViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            showPasswordCheckBox.CheckedChanged += ShowPasswordCheckBox_CheckedChanged;
        }

        // Toggle password visibility based on the checkbox
        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '*';
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            bool result = await _viewModel.LoginUserAsync(username, password);
            if (result)
            {
                MainForm mainForm = new MainForm();
                Hide();
                mainForm.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm(_viewModel);
            Hide();
            registrationForm.Show();
        }
    }
}
