using Foundation;
using SmartHotel.Clients.Core.Services.Authentication;
using SmartHotel.Clients.Core.ViewModels.Base;
using SmartHotel.Clients.iOS.Services;
using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace SmartHotel.Clients.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
