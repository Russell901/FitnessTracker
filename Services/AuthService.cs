using FitnessTracker.Interfaces;
using FitnessTracker.Models;
using FitnessTracker.Utilities;

namespace FitnessTracker.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<bool> RegisterUserAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            try
            {
                if (!userValidator.IsValidUsername(username))
                {
                    MessageBox.Show("Username must contain only letters and numbers.");
                    return false;
                }

                if (!userValidator.IsValidPassword(password))
                {
                    MessageBox.Show("Password must be at least 12 characters and contain both uppercase and lowercase letters.");
                    return false;
                }

                var existingUser = await _userRepository.GetByUsernameAsync(username);
                if (existingUser != null)
                {
                    MessageBox.Show("Username already exists.");
                    return false;
                }

                string hashedPassword = PasswordHash.HashPassword(password);
                var newUser = new User
                {
                    Username = username,
                    PasswordHash = hashedPassword,
                    CreatedAt = DateTime.UtcNow
                };

                bool success = await _userRepository.AddAsync(newUser);
                if (success)
                {
                    MessageBox.Show("User created successfully!");
                    return true;
                }

                MessageBox.Show("Failed to create user. Please try again.");
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception if you have logging configured
                MessageBox.Show("An error occurred during registration.");
                return false;
            }
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            try
            {
                var user = await _userRepository.GetByUsernameAsync(username);
                if (user == null)
                {
                    MessageBox.Show("Invalid username or password.");
                    return false;
                }

                if (!PasswordHash.VerifyPassword(password, user.PasswordHash))
                {
                    MessageBox.Show("Invalid username or password.");
                    return false;
                }

                MessageBox.Show("Login successful!");
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception if you have logging configured
                MessageBox.Show("An error occurred during login.");
                return false;
            }
        }

        // method for changing password
        public async Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null) return false;

            if (!PasswordHash.VerifyPassword(oldPassword, user.PasswordHash))
                return false;

            if (!userValidator.IsValidPassword(newPassword))
                return false;

            user.PasswordHash = PasswordHash.HashPassword(newPassword);
            return await _userRepository.UpdateAsync(user);
        }
    }
}