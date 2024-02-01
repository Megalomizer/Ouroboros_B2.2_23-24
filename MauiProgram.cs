using Camera.MAUI;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using OuroborosEvents.MVVM.Models;
using OuroborosEvents.Repositories;
using Plugin.LocalNotification;
using UraniumUI;

namespace OuroborosEvents
{
    public static class MauiProgram
    {

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCameraView()
                .UseMauiCommunityToolkit()
                .UseUraniumUI()
                .UseLocalNotification()
                .UseUraniumUIMaterial()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                    fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
                    fonts.AddFont("Poppins-Bold", "PoppinsBold");
                    fonts.AddMaterialIconFonts();
                    fonts.AddFontAwesomeIconFonts();

                });

            builder.Services.AddSingleton<BaseRepository<Activity>>();
            builder.Services.AddSingleton<BaseRepository<Address>>();
            builder.Services.AddSingleton<BaseRepository<Event>>();
            builder.Services.AddSingleton<BaseRepository<EventGuest>>();
            builder.Services.AddSingleton<BaseRepository<Exhibit>>();
            builder.Services.AddSingleton<BaseRepository<Exhibitor>>();
            builder.Services.AddSingleton<BaseRepository<Guest>>();
            builder.Services.AddSingleton<BaseRepository<Organiser>>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
