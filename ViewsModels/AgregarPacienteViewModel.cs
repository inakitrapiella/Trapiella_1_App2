using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Repos;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class AgregarPacienteViewModel : INotifyPropertyChanged
    {
        private readonly IPacienteRepo _repo;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

        public string Nombre { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }

        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
            set { _mensaje = value; OnPropertyChanged(); }
        }

        public ICommand GuardarCommand { get; }
        public ICommand CancelarCommand { get; }

        public AgregarPacienteViewModel(IPacienteRepo repo)
        {
            _repo = repo;

            GuardarCommand = new Command(async () => await Guardar());
            CancelarCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        private async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(Nombre) ||
                string.IsNullOrWhiteSpace(Especie) ||
                string.IsNullOrWhiteSpace(Raza))
            {
                Mensaje = "Complete todos los campos.";
                return;
            }

            var nuevo = new Paciente
            {
                Nombre = Nombre,
                Especie = Especie,
                Raza = Raza
            };

            await _repo.InsertAsync(nuevo);

            await Shell.Current.DisplayAlert("OK", "Paciente agregado", "Aceptar");

            await Shell.Current.GoToAsync("..");
        }
    }
}
