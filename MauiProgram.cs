using AppParcialesMauiTrapiella.Services;
using AppParcialesMauiTrapiella.ViewsModels;
using Microsoft.Extensions.Logging;

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
            builder.Services.AddSingleton<IValidacionServicio, ValidacionServicio>();

            // Registro de ViewModels
            builder.Services.AddTransient<MainPageViewModels>();

            // Registro de paginas
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
