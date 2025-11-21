using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Repos;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class PacientesViewModel : INotifyPropertyChanged
    {
        private readonly IPacienteRepo _repo;

        public ObservableCollection<Paciente> Mascotas { get; set; } = new();

        private bool _cargando;
        public bool Cargando
        {
            get => _cargando;
            set { _cargando = value; OnPropertyChanged(); }
        }

        private string _estado;
        public string Estado
        {
            get => _estado;
            set { _estado = value; OnPropertyChanged(); }
        }

        public Command CargarCommand { get; }
        public Command<Paciente> SeleccionarCommand { get; }
        public Command<Paciente> EliminarCommand { get; }
        public Command AgregarCommand { get; }


        public PacientesViewModel(IPacienteRepo repo)
        {
            _repo = repo;

            CargarCommand = new Command(async () => await Cargar());
            SeleccionarCommand = new Command<Paciente>(async (m) => await VerDetalle(m));
            EliminarCommand = new Command<Paciente>(async (m) => await Eliminar(m));
            AgregarCommand = new Command(async () => await Agregar());

        }

        private async Task Cargar()
        {
            Cargando = true;
            Mascotas.Clear();

            var lista = await _repo.GetAllAsync();
            foreach (var m in lista)
                Mascotas.Add(m);

            Estado = $"Total: {Mascotas.Count}";
            Cargando = false;
        }

        private async Task Agregar()
        {
            await Shell.Current.GoToAsync("AgregarPacientePage");
        }


        private async Task VerDetalle(Paciente m)
        {
            await Shell.Current.GoToAsync($"PacienteDetailPage?id={m.Id}");
        }

        private async Task Eliminar(Paciente m)
        {
            await _repo.DeleteAsync(m);
            Mascotas.Remove(m);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
