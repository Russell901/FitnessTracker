using FitnessTracker.Interfaces;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace FitnessTracker.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private readonly IAuthService _authService;
        private string _username;
        private string _password;
        private string _message;

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        public MainViewModel(IAuthService authService)
        {
            _authService = authService;

            var canExecute = this.WhenAnyValue(
                x => x.Username,
                x => x.Password,
                (username, password) => !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password)
                );

            RegisterCommand = ReactiveCommand.CreateFromTask(Register, canExecute);
            LoginCommand = ReactiveCommand.CreateFromTask(Login, canExecute);

        }

        private async Task Register()
        {
            var result = await _authService.RegisterUserAsync(Username, Password);
            Message = result ? "Registration successful!" : "Registration failed. Username might already exist.";
        }

        private async Task Login()
        {
            var result = await _authService.LoginAsync(Username, Password);
            Message = result ? "Login successful!" : "Login failed. Please check your credentials.";
        }
    }
}