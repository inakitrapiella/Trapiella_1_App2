using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.Services
{
    public interface IValidacionServicio
    {
        bool IsValidEmail(string email);
        bool IsValidPassword(string password);
        bool IsValidRaza(string raza);
        bool IsValidNombre(string nombre);
        bool IsValid(string campo);
    }
}
