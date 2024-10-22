using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var dbPath = Path.Combine(
        //        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        //        "FitnessTracker",
        //        "tracker.db");

        //    // Create directory if it doesn't exist
        //    var folder = Path.GetDirectoryName(dbPath);
        //    Directory.CreateDirectory(folder);

        //    optionsBuilder.UseSqlite($"Data Source={dbPath}");
        //}
    }
}
