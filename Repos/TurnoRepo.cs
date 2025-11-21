using SQLite;
using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Services;

namespace AppParcialesMauiTrapiella.Repos
{
    public class TurnoRepo : ITurnoRepo
    {
        private readonly SQLiteAsyncConnection _db;

        public TurnoRepo(BDDService db)
        {
            _db = db.Connection();
        }

        public Task<List<Turno>> GetAllAsync() =>
            _db.Table<Turno>().ToListAsync();

        public Task<Turno> GetByIdAsync(int id) =>
            _db.FindAsync<Turno>(id);

        public Task<List<Turno>> GetByMascotaIdAsync(int mascotaId) =>
            _db.Table<Turno>().Where(t => t.PacienteId == mascotaId).ToListAsync();

        public Task<int> InsertAsync(Turno turno) =>
            _db.InsertAsync(turno);

        public Task<int> UpdateAsync(Turno turno) =>
            _db.UpdateAsync(turno);

        public Task<int> DeleteAsync(Turno turno) =>
            _db.DeleteAsync(turno);
    }
}
