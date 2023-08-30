using SmartHotel.Clients.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace SmartHotel.Clients.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            Renderers.Calendar.Init();
            Xamarin.FormsMaps.Init(AppSettings.BingMapsApiKey);
            LoadApplication(new Clients.App());
            NativeCustomize();
        }

        void NativeCustomize()
        {
            // TODO Windows.UI.ViewManagement.ApplicationView is no longer supported. Use Microsoft.UI.Windowing.AppWindow instead. For more details see https://docs.microsoft.com/en-us/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/guides/windowing
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 500));

            // PC Customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                // TODO Windows.UI.ViewManagement.ApplicationView is no longer supported. Use Microsoft.UI.Windowing.AppWindow instead. For more details see https://docs.microsoft.com/en-us/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/guides/windowing
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                if (titleBar != null)
                {
                    titleBar.BackgroundColor = (Color)App.Window.Resources["NativeAccentColor"];
                    titleBar.ButtonBackgroundColor = (Color)App.Window.Resources["NativeAccentColor"];
                }
            }

            // Mobile Customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                var statusBar = StatusBar.GetForCurrentView();
                if (statusBar != null)
                {
                    statusBar.BackgroundOpacity = 1;
                    statusBar.BackgroundColor = (Color)App.Window.Resources["NativeAccentColor"];
                }
            }

            // Launch in Window Mode
            // TODO Windows.UI.ViewManagement.ApplicationView is no longer supported. Use Microsoft.UI.Windowing.AppWindow instead. For more details see https://docs.microsoft.com/en-us/windows/apps/windows-app-sdk/migrate-to-windows-app-sdk/guides/windowing
                        var currentView = ApplicationView.GetForCurrentView();
            if (currentView.IsFullScreenMode)
            {
                currentView.ExitFullScreenMode();
            }
        }
    }
}