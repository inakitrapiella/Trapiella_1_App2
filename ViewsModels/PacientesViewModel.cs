using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class PacientesViewModel: INotifyPropertyChanged
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
                    OnPropertyChanged(nameof(Mascotas));
                }
            }
        }

        private int mascotaId;

        public int MascotaId
        {
            get => mascotaId;
            set
            {
                if (mascotaId != value)
                {
                    mascotaId = value;
                    OnPropertyChanged();
                }
            }
        }

        public Command CargarCommand { get; }
        public Command SeleccionarCommand { get; }

        public PacientesViewModel(ApiService apiService)
        {
            _apiService = apiService;
            Mascotas = new ObservableCollection<Mascota>();
            CargarCommand = new Command(async () => await CargarMascotasAsync());
            SeleccionarCommand = new Command<Mascota>(async (m) => await SeleccionarMascotaAsync(m));
        }

        private async Task CargarMascotasAsync()
        {
            try
            {
                var lista = await _apiService.GetMascotas();
                Mascotas = new ObservableCollection<Mascota>(lista);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!!!!!!!!!" + e.Message);
            }

        }

        private async Task SeleccionarMascotaAsync(Mascota mascota)
        {
            await Shell.Current.GoToAsync($"PacienteDetailPage?id={mascota.Id}");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}