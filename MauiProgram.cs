using AppParcialesMauiTrapiella.Repos;
using AppParcialesMauiTrapiella.Services;
using AppParcialesMauiTrapiella.Views;
using AppParcialesMauiTrapiella.ViewsModels;
using Microsoft.Extensions.Logging;
using Microsoft.Maui;

namespace AppParcialesMauiTrapiella
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<BDDService>(sp =>
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "veterinaria.db3");
                var _db = new BDDService(dbPath);
                Task.Run(async () =>{await _db.InitializeAsync();}).Wait();
                return _db;
            });

            builder.Services.AddSingleton<IUsuarioRepo, UsuarioRepo>();
            builder.Services.AddSingleton<IPacienteRepo, PacienteRepo>();
            builder.Services.AddSingleton<ITurnoRepo, TurnoRepo>();

            // Shell y MainPage
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<MainPage>();

            // Servicios
            builder.Services.AddSingleton<IValidacionServicio, ValidacionServicio>();
            builder.Services.AddHttpClient<IApiService, ApiService>();
            builder.Services.AddSingleton<ISincronizacionServicio, SincronizacionServicio>();
            builder.Services.AddSingleton<IGpsServicio, GpsServicio>();


            // ViewModels
            builder.Services.AddTransient<MainPageViewModels>();
            builder.Services.AddTransient<MenuPrincipalViewModels>();
            builder.Services.AddTransient<PacientesViewModel>();
            builder.Services.AddTransient<PacienteDetailViewModel>();
            builder.Services.AddTransient<TurnoDetailViewModel>();
            builder.Services.AddTransient<TurnosViewModel>();
            builder.Services.AddTransient<RegistroViewModel>();
            builder.Services.AddTransient<AgregarPacienteViewModel>();
            builder.Services.AddTransient<AgregarTurnoViewModel>();

            // Paginas
            builder.Services.AddTransient<MenuPrincipal>();
            builder.Services.AddTransient<PacientePage>();
            builder.Services.AddTransient<PacienteDetailPage>();
            builder.Services.AddTransient<TurnoDetailPage>();
            builder.Services.AddTransient<TurnoPage>();
            builder.Services.AddTransient<RegistroPage>();
            builder.Services.AddTransient<AgregarPacientePage>();
            builder.Services.AddTransient<AgregarTurnoPage>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

