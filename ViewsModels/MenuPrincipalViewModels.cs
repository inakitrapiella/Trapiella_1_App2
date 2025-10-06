using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class MenuPrincipalViewModels
    {
        public Command PacientesCommand { get; }
        public Command TurnosCommand { get; }
        public Command CerrarSesionCommand { get; }

        public MenuPrincipalViewModels()
        {
            PacientesCommand = new Command(async () => await PacientesAsync());
            TurnosCommand = new Command(async () => await TurnosAsync());
            CerrarSesionCommand = new Command(async () => await CerrarSesionAsync());
        }

        private async Task PacientesAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.PacientePage));
        }

        private async Task TurnosAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.TurnoPage));
        }

        private async Task CerrarSesionAsync()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
