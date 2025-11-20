using AppParcialesMauiTrapiella.Views;

namespace AppParcialesMauiTrapiella
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MenuPrincipal), typeof(MenuPrincipal));
            Routing.RegisterRoute(nameof(TurnoPage), typeof(TurnoPage));
            Routing.RegisterRoute(nameof(PacientePage), typeof(PacientePage));
            Routing.RegisterRoute(nameof(PacienteDetailPage), typeof(PacienteDetailPage));
        }
    }
}
