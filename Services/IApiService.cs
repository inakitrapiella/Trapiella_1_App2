using AppParcialesMauiTrapiella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.Services
{
    interface IApiService
    {
       Task<IReadOnlyList<Mascota>> GetMascotas();
       Task<Mascota> GetMascotaId(int Id);
    }
}
