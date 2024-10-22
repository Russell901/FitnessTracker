namespace FitnessTracker.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(string username, string password);
        Task<bool> LoginAsync(string username, string password);
    }
}
