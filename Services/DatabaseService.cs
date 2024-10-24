using FitnessTracker.Models;
using SQLite;

namespace FitnessTracker.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService (string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Activity>().Wait();
        }

        // User operations
        public Task<List<User>> GetAllUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<User> GetUserAsync(string username)
        {
            return _database.Table<User>()
                            .Where(u => u.Username == username)
                            .FirstOrDefaultAsync();
        }

        public Task<int> UpdateUserAsync(User user)
        {
            return _database.UpdateAsync(user);
        }

        // Activity operations
        public Task<List<Activity>> GetActivitiesForUserAsync(int userId)
        {
            return _database.Table<Activity>()
                            .Where(a => a.UserId == userId)
                            .ToListAsync();
        }

        public Task<int> SaveActivityAsync(Activity activity)
        {
            return _database.InsertAsync(activity);
        }

        public Task<int> UpdateActivityAsync(Activity activity)
        {
            return _database.UpdateAsync(activity);
        }

        public Task<int> DeleteActivityAsync(Activity activity)
        {
            return _database.DeleteAsync(activity);
        }

        // FitnessGoal operations
        public Task<List<FitnessGoal>> GetFitnessGoalsForUserAsync(int userId)
        {
            return _database.Table<FitnessGoal>()
                            .Where(g => g.UserId == userId)
                            .ToListAsync();
        }

        public Task<int> SaveFitnessGoalAsync(FitnessGoal goal)
        {
            return _database.InsertAsync(goal);
        }

        public Task<FitnessGoal> GetFitnessGoalAsync(int goalId)
        {
            return _database.Table<FitnessGoal>()
                            .Where(g => g.GoalId == goalId)
                            .FirstOrDefaultAsync();
        }

        public Task<int> UpdateFitnessGoalAsync(FitnessGoal goal)
        {
            return _database.UpdateAsync(goal);
        }

        public Task<int> DeleteFitnessGoalAsync(FitnessGoal goal)
        {
            return _database.DeleteAsync(goal);
        }
    }
}
