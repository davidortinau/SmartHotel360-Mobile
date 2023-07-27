using Microsoft.Maui.Controls;
using Microsoft.Maui;

// https://github.com/xamarinhq/app-evolve 
namespace SmartHotel.Clients.Core.Controls
{
    public class ParallaxControl : ScrollView
    {
        public ParallaxControl()
        {
            Scrolled += (sender, e) => Parallax();
        }
        public static readonly BindableProperty ParallaxViewProperty =
            BindableProperty.Create(nameof(ParallaxControl), typeof(View), typeof(ParallaxControl), null);

        public View ParallaxView
        {
            get => (View)GetValue(ParallaxViewProperty);
            set => SetValue(ParallaxViewProperty, value);
        }

        double height;
        public void Parallax()
        {
            // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
            if (ParallaxView == null 
                || Device.RuntimePlatform == "Windows" 
                || Device.RuntimePlatform == "WinPhone")
                return;

            if (height <= 0)
                height = ParallaxView.Height;

            var y = -(int)((float)ScrollY / 2.5f);

            if (y < 0)
            {
                ParallaxView.Scale = 1;
                ParallaxView.TranslationY = y;
            }
            else // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
if (Device.RuntimePlatform == "iOS")
            {
                var newHeight = height + (ScrollY * -1);
                ParallaxView.Scale = newHeight / height;
                ParallaxView.TranslationY = -(ScrollY / 2);
            }
            else
            {
                ParallaxView.Scale = 1;
                ParallaxView.TranslationY = 0;
            }
        }
    }
}