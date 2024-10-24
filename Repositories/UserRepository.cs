using FitnessTracker.Data;
using FitnessTracker.Interfaces;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            try
            {
                await _context.Users.AddAsync(user);
                var saveResult = await _context.SaveChangesAsync();
                return saveResult > 0;
            }
            catch (DbUpdateException)
            {
                // Log the error if you have logging configured
                return false;
            }
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty", nameof(username));

            return await _context.Users
                .AsNoTracking() // For better performance when we only need to read
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<bool> ExistsAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty", nameof(username));

            return await _context.Users
                .AsNoTracking()
                .AnyAsync(u => u.Username.ToLower() == username.ToLower());
        }

        // Optional: Add a method to update user details
        public async Task<bool> UpdateAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            try
            {
                _context.Users.Update(user);
                var saveResult = await _context.SaveChangesAsync();
                return saveResult > 0;
            }
            catch (DbUpdateException)
            {
                // Log the error if you have logging configured
                return false;
            }
        }

        // Optional: Add a method to delete a user
        public async Task<bool> DeleteAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            try
            {
                _context.Users.Remove(user);
                var saveResult = await _context.SaveChangesAsync();
                return saveResult > 0;
            }
            catch (DbUpdateException)
            {
                // Log the error if you have logging configured
                return false;
            }
        }
    }
}