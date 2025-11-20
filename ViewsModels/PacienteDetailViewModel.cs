using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    [QueryProperty(nameof(Id), "id")]
    public class PacienteDetailViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private int _id;
        private Mascota _mascota;

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    _ = CargarAsync();                  
                }
            }
        }

        public Mascota Mascota
        {
            get => _mascota;
            set
            {
                if (_mascota != value)
                {
                    _mascota = value;
                    OnPropertyChanged(nameof(Mascota));
                }
            }
        }

        public string Nombre => Mascota?.Nombre ?? "";
        public string Especie => Mascota?.Especie ?? "";
        public string Raza => Mascota?.Raza ?? "";

        public PacienteDetailViewModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        private async Task CargarAsync()
        {
            try
            {
                var m = await _apiService.GetMascotaId(Id);
                Mascota = m;
                OnPropertyChanged(nameof(Nombre));
                OnPropertyChanged(nameof(Especie));
                OnPropertyChanged(nameof(Raza));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
