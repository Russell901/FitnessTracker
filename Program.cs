using FitnessTracker.Data;
using FitnessTracker.Interfaces;
using FitnessTracker.Repositories;
using FitnessTracker.Services;
using FitnessTracker.ViewModels;
using FitnessTracker.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace FitnessTracker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ApplicationConfiguration.Initialize();

            // Set up dependency injection
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Ensure database is created
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

            // Create main form with dependencies
            var initial = serviceProvider.GetRequiredService<LoginForm>();

            Application.Run(initial);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // Get the database path
            var dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "FitnessTracker",
                "fitness_app.db");

            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath));

            // Register DbContext with proper configuration
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"),
                ServiceLifetime.Singleton);

            // Register repositories
            services.AddSingleton<IUserRepository, UserRepository>();

            // Register services
            services.AddSingleton<IAuthService, AuthService>();

            // Register ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<UserViewModel>();

            // Register Forms
            services.AddTransient<MainForm>();
            services.AddTransient<LoginForm>();
            services.AddTransient<RegistrationForm>();
        }
    }
}