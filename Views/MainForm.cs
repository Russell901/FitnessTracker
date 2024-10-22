using FitnessTracker.Data;
using FitnessTracker.Repositories;
using FitnessTracker.Services;
using FitnessTracker.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace FitnessTracker.Views
{
    public class MainForm : Form, IViewFor<MainViewModel>
    {
        private TextBox nameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Button registerButton;
        private Label messageLabel;

        public MainViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainViewModel)value;
        }

        public MainForm( MainViewModel viewModel)
        {
            InitializeComponent();
            
            var dbContext = new AppDbContext();
            var userRepository = new UserRepository(dbContext);
            var authService = new AuthService(userRepository);

            ViewModel = viewModel;

            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, vm => vm.Username, v => v.nameTextBox.Text)
                    .DisposeWith(disposables);
                this.Bind(ViewModel, vm => vm.Password, v => v.passwordTextBox.Text)
                    .DisposeWith(disposables);
                this.Bind(ViewModel, vm => vm.Message, v => v.messageLabel.Text)
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel, vm => vm.RegisterCommand, v => v.registerButton)
                    .DisposeWith(disposables);
                this.BindCommand(ViewModel, vm => vm.LoginCommand, v => v.loginButton)
                    .DisposeWith(disposables);
            });
        }

        private void InitializeComponent()
        {
            nameTextBox = new TextBox();
            loginButton = new Button();
            messageLabel = new Label();
            passwordTextBox = new TextBox();
            registerButton = new Button();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(268, 194);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(200, 23);
            nameTextBox.TabIndex = 0;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(322, 278);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(88, 36);
            loginButton.TabIndex = 1;
            loginButton.Text = "Login";
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Location = new Point(367, 98);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(0, 15);
            messageLabel.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(270, 230);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(198, 23);
            passwordTextBox.TabIndex = 3;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(322, 342);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(88, 40);
            registerButton.TabIndex = 4;
            registerButton.Text = "Register";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registerButton);
            Controls.Add(passwordTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(loginButton);
            Controls.Add(messageLabel);
            Name = "MainForm";
            Text = "Fitness Tracker";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}