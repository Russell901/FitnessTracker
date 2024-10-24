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
    public partial class RegistrationForm : Form
    {
        private readonly UserViewModel _viewModel;
       
        public RegistrationForm(UserViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;

            showPasswordCheckBox.CheckedChanged += ShowPasswordCheckBox_CheckedChanged;
        }

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '*';
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            bool result = await _viewModel.RegisterUserAsync(username, password);
            if (result)
            {
                LoginForm login = new LoginForm(_viewModel);
                Hide();
                login.Show();
            }
        }
    }
}
