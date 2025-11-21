using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.Services
{
    public class GpsServicio : IGpsServicio
    {
        public async Task<(double lat, double lon)> ObtenerUbicacionAsync()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if (status != PermissionStatus.Granted)
                        throw new Exception("Permiso de GPS denegado.");
                }

                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location is null)
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.High,
                        Timeout = TimeSpan.FromSeconds(10)
                    });

                if (location is null)
                    throw new Exception("No se pudo obtener la ubicacion.");

                return (location.Latitude, location.Longitude);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
