using Microsoft.Extensions.Logging;
using NavSQLWS.Services;
using NavSQLWS.ViewModels;

namespace NavSQLWS;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<Views.NewPage1>();
        builder.Services.AddSingleton<NewPage1ViewModel>();

        builder.Services.AddSingleton<Views.MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();

        builder.Services.AddSingleton<Views.InfoPage>();
        builder.Services.AddSingleton<InfoPageViewModel>();


        builder.Services.AddSingleton<DbConnection>();

        return builder.Build();
    }
}
