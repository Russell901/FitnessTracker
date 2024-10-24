using FitnessTracker.Interfaces;
using FitnessTracker.Models;
using FitnessTracker.Services;
using FitnessTracker.Utilities;

namespace FitnessTracker.ViewModels
{
    public class UserViewModel
    {
        private readonly IAuthService _authService;

        public UserViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<bool> RegisterUserAsync(string username, string password)
        {
            if (await _authService.RegisterUserAsync(username, password))
            {
                MessageBox.Show("User created successfully!");
                return true;
            }
            else
            {
                // You might want to have more specific error messages based on what failed
                MessageBox.Show("Registration failed. Please check username and password requirements.");
                return false;
            }
        }

        public async Task<bool> LoginUserAsync(string username, string password)
        {
            if (await _authService.LoginAsync(username, password))
            {
                MessageBox.Show("Login successful!");
                return true;
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
                return false;
            }
        }

    }
}
