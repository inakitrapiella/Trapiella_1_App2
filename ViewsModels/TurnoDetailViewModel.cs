using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Repos;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class TurnoDetailViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private readonly ITurnoRepo _repo;

        public Turno Turno { get; set; }

        public TurnoDetailViewModel(ITurnoRepo repo)
        {
            _repo = repo;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int id = int.Parse(query["id"].ToString());
            Turno = await _repo.GetByIdAsync(id);
            OnPropertyChanged(nameof(Turno));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }
}
