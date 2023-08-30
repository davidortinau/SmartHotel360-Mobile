using SmartHotel.Clients.Core.Models;
using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Converters
{
    public class NotificationTypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is NotificationType notificationType)
            {
                switch (notificationType)
                {
                    case NotificationType.BeGreen:
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? string.Format("Assets/ic_be_green{0}.png", parameter ?? string.Empty) : string.Format("ic_be_green{0}", parameter ?? string.Empty);
                    case NotificationType.Hotel:
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? string.Format("Assets/ic_hotel{0}.png", parameter ?? string.Empty) : string.Format("ic_hotel{0}", parameter ?? string.Empty);
                    case NotificationType.Room:
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? string.Format("Assets/ic_room{0}.png", parameter ?? string.Empty) : string.Format("ic_room{0}", parameter ?? string.Empty);
                    case NotificationType.Other:
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? string.Format("Assets/ic_others{0}.png", parameter ?? string.Empty) : string.Format("ic_others{0}", parameter ?? string.Empty);
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}