using AppParcialesMauiTrapiella.Views;

namespace AppParcialesMauiTrapiella
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegistroPage), typeof(RegistroPage));

            Routing.RegisterRoute(nameof(MenuPrincipal), typeof(MenuPrincipal));
            Routing.RegisterRoute(nameof(TurnoPage), typeof(TurnoPage));
            Routing.RegisterRoute(nameof(TurnoDetailPage), typeof(TurnoDetailPage));
            Routing.RegisterRoute(nameof(PacientePage), typeof(PacientePage));
            Routing.RegisterRoute(nameof(PacienteDetailPage), typeof(PacienteDetailPage));
            Routing.RegisterRoute(nameof(AgregarPacientePage), typeof(AgregarPacientePage));
            Routing.RegisterRoute(nameof(AgregarTurnoPage), typeof(AgregarTurnoPage));

        }
    }
}
