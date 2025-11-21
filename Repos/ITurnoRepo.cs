using AppParcialesMauiTrapiella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.Repos
{
    public interface ITurnoRepo
    {
        Task<List<Turno>> GetAllAsync();
        Task<Turno> GetByIdAsync(int id);
        Task<int> InsertAsync(Turno turno);
        Task<int> UpdateAsync(Turno turno);
        Task<int> DeleteAsync(Turno turno);
        Task<List<Turno>> GetByMascotaIdAsync(int mascotaId);
    }
}
