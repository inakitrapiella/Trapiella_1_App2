using AppParcialesMauiTrapiella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.Repos
{
    public interface IPacienteRepo
    {
        Task<List<Paciente>> GetAllAsync();
        Task<Paciente> GetByIdAsync(int id);
        Task<int> InsertAsync(Paciente mascota);
        Task<int> UpdateAsync(Paciente mascota);
        Task<int> DeleteAsync(Paciente mascota);
    }
}
