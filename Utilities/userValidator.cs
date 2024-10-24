using System.Text.RegularExpressions;

namespace FitnessTracker.Utilities
{
    public static class userValidator
    {
        public static bool IsValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]+$");
        }

        public static bool IsValidPassword(string password)
        {
            if (password.Length < 12) return false;
            bool hasLower = password.Any(char.IsLower);
            bool hasUpper = password.Any(char.IsUpper);
            return hasLower && hasUpper;
        }
    }
}
