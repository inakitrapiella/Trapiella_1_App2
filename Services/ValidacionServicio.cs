using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.Services
{
    public class ValidacionServicio : IValidacionServicio
    {
        public bool IsValid(string campo)
        {
            return !string.IsNullOrWhiteSpace(campo);
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        public bool IsValidNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            string pattern = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$";
            return Regex.IsMatch(nombre, pattern);
        }

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 6)
            {
                return false;
            }
            return true;
        }

        public bool IsValidRaza(string raza)
        {
            return !string.IsNullOrWhiteSpace(raza);
        }
    }
}