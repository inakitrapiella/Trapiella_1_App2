using SQLite;
using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Services;

namespace AppParcialesMauiTrapiella.Repos
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly SQLiteAsyncConnection _db;

        public UsuarioRepo(BDDService db)
        {
            _db = db.Connection();
        }

        public Task<int> InsertAsync(Usuario usuario) =>
            _db.InsertAsync(usuario);

        public Task<Usuario> GetByMailAsync(string email) =>
            _db.Table<Usuario>().Where(u => u.Mail == email).FirstOrDefaultAsync();

        public async Task<Usuario> LoginAsync(string email, string password)
        {
            return await _db.Table<Usuario>()
                .Where(u => u.Mail == email && u.Contrasena == password)
                .FirstOrDefaultAsync();
        }
    }
}
