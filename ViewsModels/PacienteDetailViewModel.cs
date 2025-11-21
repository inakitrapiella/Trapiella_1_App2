using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Repos;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class PacienteDetailViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private readonly IPacienteRepo _repo;

        public Paciente Mascota { get; set; }

        public string Nombre => Mascota?.Nombre;
        public string Especie => Mascota?.Especie;
        public string Raza => Mascota?.Raza;

        public PacienteDetailViewModel(IPacienteRepo repo)
        {
            _repo = repo;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int id = int.Parse(query["id"].ToString());
            Mascota = await _repo.GetByIdAsync(id);
            OnPropertyChanged(nameof(Nombre));
            OnPropertyChanged(nameof(Especie));
            OnPropertyChanged(nameof(Raza));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }
}
