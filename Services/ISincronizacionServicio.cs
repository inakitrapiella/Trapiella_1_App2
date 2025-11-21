using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.Services
{
    public interface ISincronizacionServicio
    {
        Task SincronizarPacientesAsync();
    }
}
