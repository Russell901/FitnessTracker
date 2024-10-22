using FitnessTracker.Interfaces;
using FitnessTracker.Models;
using System.Security.Cryptography;
using System.Text;

namespace FitnessTracker.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUserAsync(string username, string password)
        {
            if (await _userRepository.UserExistsAsync(username))
            {
                return false;
            }

            var hashedPassword = HashPassword(password);
            var user = new User
            {
                Username = username,
                PasswordHash = hashedPassword
            };

            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return false;
            }

            return VerifyPassword(password, user.PasswordHash);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            return HashPassword(password) == storedHash;
        }
    }


}
