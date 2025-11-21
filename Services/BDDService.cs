using AppParcialesMauiTrapiella.Models;
using SQLite;

namespace AppParcialesMauiTrapiella.Services
{
    public class BDDService
    {
        private readonly SQLiteAsyncConnection _db;
        private bool _initialized;

        public BDDService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
        }

        public SQLiteAsyncConnection Connection() => _db;

        public async Task InitializeAsync()
        {
            if (_initialized)
                return;

            await _db.CreateTableAsync<Usuario>();
            await _db.CreateTableAsync<Paciente>();
            await _db.CreateTableAsync<Turno>();

            _initialized = true;
        }
    }
}
