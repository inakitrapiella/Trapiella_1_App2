using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Repos;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    [QueryProperty(nameof(TurnoId), "id")]
    public class AgregarTurnoViewModel : INotifyPropertyChanged
    {
        private readonly ITurnoRepo _turnoRepo;
        private readonly IPacienteRepo _pacienteRepo;

        private int _turnoId = 0;
        public int TurnoId
        {
            get => _turnoId;
            set
            {
                _turnoId = value;
                _ = CargarParaEditar(value);
            }
        }
        public bool EsEdicion => TurnoId != 0;


        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Motivo { get; set; }

        public ObservableCollection<Paciente> Pacientes { get; set; } = new();

        private Paciente _pacienteSeleccionado;
        public Paciente PacienteSeleccionado
        {
            get => _pacienteSeleccionado;
            set { _pacienteSeleccionado = value; OnPropertyChanged(); }
        }

        public Command GuardarCommand { get; }
        public Command CancelarCommand { get; }

        public AgregarTurnoViewModel(ITurnoRepo turnoRepo, IPacienteRepo pacienteRepo)
        {
            _turnoRepo = turnoRepo;
            _pacienteRepo = pacienteRepo;

            GuardarCommand = new Command(async () => await Guardar());
            CancelarCommand = new Command(async () => await Shell.Current.GoToAsync(".."));

            _ = CargarPacientes();
        }

        private async Task CargarPacientes()
        {
            Pacientes.Clear();

            var lista = await _pacienteRepo.GetAllAsync();

            foreach (var p in lista)
                Pacientes.Add(p);
        }

        private async Task Guardar()
        {
            if (PacienteSeleccionado == null)
            {
                await Shell.Current.DisplayAlert("Error", "Debe seleccionar un paciente.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Motivo))
            {
                await Shell.Current.DisplayAlert("Error", "Debe ingresar un motivo.", "OK");
                return;
            }

            var nuevo = new Turno
            {
                Fecha = Fecha,
                Motivo = Motivo,
                PacienteId = PacienteSeleccionado.Id,
            };

            await _turnoRepo.InsertAsync(nuevo);

            await Shell.Current.DisplayAlert("OK", "Turno guardado correctamente.", "Aceptar");
            await Shell.Current.GoToAsync("..");
        }

        private async Task CargarParaEditar(int id)
        {
            if (id == 0) return;

            var turno = await _turnoRepo.GetByIdAsync(id);
            if (turno == null) return;

            Fecha = turno.Fecha;
            Motivo = turno.Motivo;

            if (Pacientes.Count == 0)
                await CargarPacientes();

            PacienteSeleccionado = Pacientes.FirstOrDefault(p => p.Id == turno.PacienteId);

            OnPropertyChanged(nameof(Fecha));
            OnPropertyChanged(nameof(Motivo));
            OnPropertyChanged(nameof(PacienteSeleccionado));
            OnPropertyChanged(nameof(EsEdicion));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
