using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParcialesMauiTrapiella.ViewsModels
{
    public class MainPageViewModels
    {
        public Command LoginCommand { get; }

        public MainPageViewModels()
        {
            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.MenuPrincipal));
        }
    }
}
