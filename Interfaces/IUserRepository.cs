using FitnessTracker.Models;

namespace FitnessTracker.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task<bool> UserExistsAsync(string username);
    }
}
