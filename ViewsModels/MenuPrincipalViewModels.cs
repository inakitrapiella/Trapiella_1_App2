using AppParcialesMauiTrapiella.Repos;
using AppParcialesMauiTrapiella.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class MenuPrincipalViewModels : INotifyPropertyChanged
    {
        private readonly IGpsServicio _gpsServicio;

        private string ubicacion;
        public string Ubicacion
        {
            get => ubicacion;
            set { ubicacion = value; OnPropertyChanged(); }
        }

        public Command ObtenerUbicacionCommand { get; }

        public ICommand PacientesCommand { get; }
        public ICommand TurnosCommand { get; }
        public ICommand CerrarSesionCommand { get; }

        public MenuPrincipalViewModels(IGpsServicio gpsServicio)
        {
            _gpsServicio = gpsServicio;
            ObtenerUbicacionCommand = new Command(async () => await ObtenerUbicacion());

            PacientesCommand = new Command(async () =>
                await Shell.Current.GoToAsync(nameof(AppParcialesMauiTrapiella.Views.PacientePage)));

            TurnosCommand = new Command(async () =>
                await Shell.Current.GoToAsync(nameof(AppParcialesMauiTrapiella.Views.TurnoPage)));

            CerrarSesionCommand = new Command(async () =>
                await Shell.Current.GoToAsync("///MainPage"));
        }

        private async Task ObtenerUbicacion()
        {
            try
            {
                var (lat, lon) = await _gpsServicio.ObtenerUbicacionAsync();
                Ubicacion = $"Lat: {lat:0.0000}  |  Lon: {lon:0.0000}";
            }
            catch (Exception ex)
            {
                Ubicacion = "Error obteniendo ubicacion";

                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));

                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
