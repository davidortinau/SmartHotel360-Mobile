using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Controls
{
    public partial class iOSStatusBarBackground : ContentView
	{
		public iOSStatusBarBackground ()
		{
			InitializeComponent ();
            // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
            IsVisible = Device.RuntimePlatform == Device.iOS;
		}

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
            if (propertyName == IsVisibleProperty.PropertyName 
                && IsVisible 
                && Device.RuntimePlatform != Device.iOS)
            {
                IsVisible = false;
            }
        }
    }
}