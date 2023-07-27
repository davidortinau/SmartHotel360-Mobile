using SmartHotel.Clients.Core.Extensions;
using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Converters
{
    public class HotelImageConverter : IValueConverter
    {
        Random rnd = new Random();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (AppSettings.UseFakes)
            {
                if (value != null)
                {
                    return value;
                }
                else
                {
                    var index = rnd.Next(1, 9);
                    // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                    return Device.RuntimePlatform == Device.UWP ? string.Format("Assets/i_hotel_{0}.jpg", index) : string.Format("i_hotel_{0}", index);
                }
            }
            else if (value != null)
            {
                var builder = new UriBuilder(AppSettings.ImagesBaseUri);
                builder.AppendToPath(value.ToString());

                return builder.ToString();
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}