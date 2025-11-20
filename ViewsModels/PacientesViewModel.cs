using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class PacientesViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        private ObservableCollection<Mascota> mascotas;
        public ObservableCollection<Mascota> Mascotas
        {
            get => mascotas;
            set
            {
                if (mascotas != value)
                {
                    mascotas = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool cargando;
        public bool Cargando
        {
            get => cargando;
            set
            {
                cargando = value;
                OnPropertyChanged();
            }
        }

        private string estado;
        public string Estado
        {
            get => estado;
            set
            {
                estado = value;
                OnPropertyChanged();
            }
        }

        public ICommand CargarCommand { get; }
        public ICommand SeleccionarCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand EliminarCommand { get; }

        public PacientesViewModel(ApiService apiService)
        {
            _apiService = apiService;
            Mascotas = new ObservableCollection<Mascota>();

            CargarCommand = new Command(async () => await CargarMascotasAsync());
            SeleccionarCommand = new Command<Mascota>(async (m) => await SeleccionarMascotaAsync(m));
            EditarCommand = new Command<Mascota>(async (m) => await EditarMascotaAsync(m));
            EliminarCommand = new Command<Mascota>(async (m) => await EliminarMascotaAsync(m));
        }

        private async Task CargarMascotasAsync()
        {
            try
            {
                Cargando = true;
                Estado = "Cargando mascotas...";
                var lista = await _apiService.GetMascotas();
                Mascotas = new ObservableCollection<Mascota>(lista);
                Estado = $"Se cargaron {Mascotas.Count} mascotas";
            }
            catch (Exception e)
            {
                Estado = $"Error al cargar mascotas: {e.Message}";
            }
            finally
            {
                Cargando = false;
            }
        }

        private async Task SeleccionarMascotaAsync(Mascota mascota)
        {
            if (mascota == null) return;
            await Shell.Current.GoToAsync($"PacienteDetailPage?id={mascota.Id}");
        }

        private async Task EditarMascotaAsync(Mascota mascota)
        {
            if (mascota == null) return;
            await Shell.Current.GoToAsync($"PacienteEditPage?id={mascota.Id}");
        }

        private async Task EliminarMascotaAsync(Mascota mascota)
        {
            if (mascota == null) return;

            bool confirmar = await Application.Current.MainPage.DisplayAlert(
                "Confirmar",
                $"¿Desea eliminar a {mascota.Nombre}?",
                "Sí",
                "No");

            if (!confirmar) return;

            try
            {
                Cargando = true;
                bool eliminado = await _apiService.EliminarMascota(mascota.Id);

                if (eliminado)
                {
                    Mascotas.Remove(mascota);
                    Estado = $"Mascota {mascota.Nombre} eliminada.";
                }
                else
                {
                    Estado = $"No se pudo eliminar {mascota.Nombre}.";
                }
            }
            catch (Exception e)
            {
                Estado = $"Error al eliminar: {e.Message}";
            }
            finally
            {
                Cargando = false;
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}