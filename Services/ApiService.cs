using AppParcialesMauiTrapiella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace AppParcialesMauiTrapiella.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _http;

        public ApiService(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("https://68e339a58e14f4523daccb73.mockapi.io/");
        }

        public async Task<IReadOnlyList<Mascota>> GetMascotas()
        {
            try
            {
                var response = await _http.GetAsync("mascotas");

                if (!response.IsSuccessStatusCode)
                {
                    string mensajeError = response.StatusCode switch
                    {
                        System.Net.HttpStatusCode.NotFound => "No se encontraron las mascotas. Intenta de nuevo",
                        System.Net.HttpStatusCode.BadRequest => "Solicitud invalida. Verifica los parametros enviados",
                        System.Net.HttpStatusCode.Unauthorized => "No autorizado. Verifica tus credenciales",
                        System.Net.HttpStatusCode.InternalServerError => "Error del servidor. Intenta nuevamente mas tarde",
                    };

                    throw new Exception(mensajeError);
                }

                var contenido = await response.Content.ReadFromJsonAsync<List<Mascota>>();
                if (contenido == null)
                    throw new Exception("No se pudo interpretar la respuesta de la API");

                return contenido;
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error de conexion con la API");
            }
            catch (Exception)
            {
                throw new Exception("Error inesperado al obtener las mascotas");
            }
        }

        public async Task<Mascota> GetMascotaId(int id)
        {
            try
            {
             
                var response = await _http.GetAsync($"mascotas/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    string mensajeError = response.StatusCode switch
                    {
                        System.Net.HttpStatusCode.NotFound => "No se encontro la mascota. Intenta de nuevo",
                        System.Net.HttpStatusCode.BadRequest => "Solicitud invalida. Verifica los parametros enviados",
                        System.Net.HttpStatusCode.Unauthorized => "No autorizado. Verifica tus credenciales",
                        System.Net.HttpStatusCode.InternalServerError => "Error del servidor. Intenta nuevamente mas tarde",
                    };

                    throw new Exception(mensajeError);
                }

                var contenido = await response.Content.ReadFromJsonAsync<Mascota>();
                if (contenido == null)
                    throw new Exception("No se pudo interpretar la respuesta de la API");

                return contenido;
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error de conexion con la API");
            }
            catch (Exception)
            {
                throw new Exception("Error inesperado al obtener la mascota");
            }
        }
    }
}
