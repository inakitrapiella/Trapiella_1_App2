using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Repos;
using System.Collections.ObjectModel;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class TurnosViewModel
    {
        private readonly ITurnoRepo _repo;

        public ObservableCollection<Turno> Turnos { get; set; } = new();

        public Command CargarCommand { get; }
        public Command<Turno> VerDetalleCommand { get; }
        public Command AgregarCommand { get; }
        public Command<Turno> EditarCommand { get; }
        public Command<Turno> EliminarCommand { get; }


        public TurnosViewModel(ITurnoRepo repo)
        {
            _repo = repo;

            CargarCommand = new Command(async () => await Cargar());

            VerDetalleCommand = new Command<Turno>(async (t) =>
            {
                if (t == null) return;
                await Shell.Current.GoToAsync($"TurnoDetailPage?id={t.Id}");
            });

            EditarCommand = new Command<Turno>(async (t) =>
                await Shell.Current.GoToAsync($"AgregarTurnoPage?id={t.Id}"));

            EliminarCommand = new Command<Turno>(async (t) => await Eliminar(t));

            AgregarCommand = new Command(async () =>
                await Shell.Current.GoToAsync("AgregarTurnoPage"));
        }


        private async Task Eliminar(Turno t)
        {
            bool confirmar = await Shell.Current.DisplayAlert(
                "Eliminar turno",
                "¿Estas seguro?",
                "Si", "No");

            if (!confirmar) return;

            await _repo.DeleteAsync(t);

            Turnos.Remove(t);
        }


        private async Task Cargar()
        {
            Turnos.Clear();
            var lista = await _repo.GetAllAsync();
            foreach (var t in lista)
                Turnos.Add(t);
        }
    }
}
