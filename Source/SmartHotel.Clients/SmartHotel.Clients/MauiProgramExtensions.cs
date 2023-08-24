using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microcharts.Maui;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using SmartHotel.Clients;

namespace SmartHotel.Clients.Core;

public static class MauiProgramExtensions
{
	public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
	{
		builder
			.UseMauiApp<App>()
			.UseMauiCompatibility()
			.UseMauiCommunityToolkit()
			.UseFFImageLoading()
			.UseMicrocharts()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FiraSans_Bold.ttf", "FiraSansBold");
				fonts.AddFont("FiraSans_Regular.ttf", "FiraSansRegular");
				fonts.AddFont("FiraSans_SemiBold.ttf", "FiraSansSemiBold");

				fonts.AddFont("Poppins_Bold.ttf", "PoppinsBold");
				fonts.AddFont("Poppins_Light.ttf", "PoppinsLight");
				fonts.AddFont("Poppins_Medium.ttf", "PoppinsMedium");
				fonts.AddFont("Poppins_Regular.ttf", "PoppinsRegular");
				fonts.AddFont("Poppins_SemiBold.ttf", "PoppinsSemiBold");
			});

		OverrideHandlers();

#if DEBUG
		// builder.Logging.AddDebug();
#endif

		return builder;
	}
	
	private static void OverrideHandlers()
	{
#if ANDROID
        Microsoft.Maui.Handlers.SliderHandler.Mapper.AppendToMapping("AllThumbs", (handler, slider) =>
        {
	        // TODO this prop may no longer exist on Android
            // handler.PlatformView.IsThumbToolTipEnabled = false;  
        });
#endif
	}
}
