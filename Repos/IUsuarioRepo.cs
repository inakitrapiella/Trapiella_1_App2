using AppParcialesMauiTrapiella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.Repos
{
    public interface IUsuarioRepo
    {
        Task<int> InsertAsync(Usuario usuario);
        Task<Usuario> LoginAsync(string email, string password);
        Task<Usuario> GetByMailAsync(string email);
    }
}
