using AppParcialesMauiTrapiella.Repos;
using AppParcialesMauiTrapiella.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class MainPageViewModels : INotifyPropertyChanged
    {
        private readonly IUsuarioRepo _usuarioRepo;
        private readonly ISincronizacionServicio _sincronizacionServicio;

        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isBusy;
        private bool _hasError;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public bool HasError
        {
            get => _hasError;
            set { _hasError = value; OnPropertyChanged(); }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand IrARegistroCommand { get; }

        public MainPageViewModels(IUsuarioRepo usuarioRepo, ISincronizacionServicio sincronizacionServicio)
        {
            _usuarioRepo = usuarioRepo;
            _sincronizacionServicio = sincronizacionServicio;
            _ = _sincronizacionServicio.SincronizarPacientesAsync();
            LoginCommand = new Command(async () => await LoginAsync());
            IrARegistroCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(AppParcialesMauiTrapiella.Views.RegistroPage)));
        }

        private async Task LoginAsync()
        {
            HasError = false;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Username))
            {
                HasError = true;
                ErrorMessage = "Ingrese su email.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                HasError = true;
                ErrorMessage = "Ingrese su contraseña.";
                return;
            }

            try
            {
                IsBusy = true;

                var user = await _usuarioRepo.GetByMailAsync(Username);

                if (user == null || user.Contrasena != Password)
                {
                    HasError = true;
                    ErrorMessage = "Usuario o contraseña incorrectos.";
                    return;
                }

                await Shell.Current.GoToAsync(nameof(AppParcialesMauiTrapiella.Views.MenuPrincipal));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
