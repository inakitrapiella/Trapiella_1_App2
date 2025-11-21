using AppParcialesMauiTrapiella.Models;
using AppParcialesMauiTrapiella.Repos;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.Services
{
    public class SincronizacionServicio : ISincronizacionServicio
    {
        private readonly IApiService _api;
        private readonly IPacienteRepo _pacienteRepo;

        public SincronizacionServicio (IApiService api, IPacienteRepo pacienteRepo)
        {
            _api = api;
            _pacienteRepo = pacienteRepo;
        }

        public async Task SincronizarPacientesAsync()
        {
            var apiMascotas = await _api.GetMascotas();
            var dbMascotas = await _pacienteRepo.GetAllAsync();

            foreach (var mascota in apiMascotas)
            {
                if (!dbMascotas.Any(m => m.Nombre == mascota.Nombre))
                {
                    await _pacienteRepo.InsertAsync(mascota);
                }
            }
        }
    }
}
