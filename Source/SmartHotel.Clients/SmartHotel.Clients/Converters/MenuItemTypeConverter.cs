using SmartHotel.Clients.Core.Models;
using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Converters
{
    public class MenuItemTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var menuItemType = (MenuItemType)value;

            // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
            var platform = Device.RuntimePlatform == Device.UWP;

            switch (menuItemType)
            {
                case MenuItemType.Home:
                    return platform ? "Assets/ic_home.png" : "ic_home.png";
                case MenuItemType.BookRoom:
                    return platform ? "Assets/ic_bed.png" : "ic_bed.png";
                case MenuItemType.MyRoom:
                    return platform ? "Assets/ic_key.png" : "ic_key.png";
                case MenuItemType.Suggestions:
                    return platform ? "Assets/ic_beach.png" : "ic_beach.png";
                case MenuItemType.Concierge:
                    return platform ? "Assets/ic_bot.png" : "ic_bot.png";
                case MenuItemType.Logout:
                    return platform ? "Assets/ic_logout.png" : "ic_logout.png";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}