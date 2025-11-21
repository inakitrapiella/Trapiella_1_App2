using SQLite;
using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Services;

namespace AppParcialesMauiTrapiella.Repos
{
    public class PacienteRepo : IPacienteRepo
    {
        private readonly SQLiteAsyncConnection _db;

        public PacienteRepo(BDDService db)
        {
            _db = db.Connection();
        }

        public Task<List<Paciente>> GetAllAsync() =>
            _db.Table<Paciente>().ToListAsync();

        public Task<Paciente> GetByIdAsync(int id) =>
            _db.FindAsync<Paciente>(id);

        public Task<int> InsertAsync(Paciente mascota) =>
            _db.InsertAsync(mascota);

        public Task<int> UpdateAsync(Paciente mascota) =>
            _db.UpdateAsync(mascota);

        public Task<int> DeleteAsync(Paciente mascota) =>
            _db.DeleteAsync(mascota);
    }
}
