using FitnessTracker.Models;

namespace FitnessTracker.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User user);
        Task<User> GetByUsernameAsync(string username);
        Task<bool> ExistsAsync(string username);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int userId);
    }
}
