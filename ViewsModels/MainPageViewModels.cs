using AppParcialesMauiTrapiella.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class MainPageViewModels : INotifyPropertyChanged
    {
        private readonly IValidacionServicio _validacionServicio;

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

        public MainPageViewModels(IValidacionServicio validacionServicio)
        {
            _validacionServicio = validacionServicio;

            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            HasError = false;
            ErrorMessage = string.Empty;

            if (!_validacionServicio.IsValid(Username))
            {
                ErrorMessage = "El usuario no puede estar vacio.";
                HasError = true;
                return;
            }

            if (!_validacionServicio.IsValidPassword(Password))
            {
                ErrorMessage = "La contraseña debe tener al menos 6 caracteres, incluyendo letras y numeros.";
                HasError = true;
                return;
            }

            try
            {
                IsBusy = true;

                await Task.Delay(1000);

                await Shell.Current.GoToAsync(nameof(AppParcialesMauiTrapiella.Views.MenuPrincipal));
            }
            catch (Exception ex)
            {
                HasError = true;
                ErrorMessage = $"Error al iniciar sesion: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}