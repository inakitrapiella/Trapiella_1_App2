using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Repos;
using AppParcialesMauiTrapiella.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class RegistroViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private readonly IUsuarioRepo _usuarioRepo;
        private readonly IValidacionServicio _validacion;

        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        private string _repetirPassword;
        public string RepetirPassword
        {
            get => _repetirPassword;
            set { _repetirPassword = value; OnPropertyChanged(); }
        }

        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
            set { _mensaje = value; OnPropertyChanged(); }
        }

        public ICommand RegistrarCommand { get; }
        public ICommand VolverCommand { get; }

        public RegistroViewModel(IUsuarioRepo usuarioRepo, IValidacionServicio validacion)
        {
            _usuarioRepo = usuarioRepo;
            _validacion = validacion;

            RegistrarCommand = new Command(async () => await RegistrarAsync());
            VolverCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        private async Task RegistrarAsync()
        {
            Mensaje = "";

            if (!_validacion.IsValidEmail(Email))
            {
                Mensaje = "El email no es valido.";
                return;
            }

            if (!_validacion.IsValidPassword(Password))
            {
                Mensaje = "La contraseña debe tener al menos 6 caracteres.";
                return;
            }

            if (Password != RepetirPassword)
            {
                Mensaje = "Las contraseñas no coinciden.";
                return;
            }

            var usuarioExistente = await _usuarioRepo.GetByMailAsync(Email);

            if (usuarioExistente != null)
            {
                Mensaje = "El email ya esta registrado.";
                return;
            }

            var nuevo = new Usuario
            {
                Mail = Email,
                Contrasena = Password
            };

            await _usuarioRepo.InsertAsync(nuevo);

            await Shell.Current.DisplayAlert("Exito", "Usuario creado correctamente", "OK");

            await Shell.Current.GoToAsync("..");
        }
    }
}
