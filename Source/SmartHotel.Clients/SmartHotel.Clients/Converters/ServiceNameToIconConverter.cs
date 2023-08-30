using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Converters
{
    public class ServiceNameToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!string.IsNullOrEmpty(value.ToString()))
            {
                var icon = value.ToString();

                switch(icon)
                {
                    case "Airport shuttle":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_airport_shutle.png" : "ic_airport_shutle";
                    case "Bath":
                    case "Shared bath":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_bath.png" : "ic_bath";
                    case "Breakfast":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_breakfast.png" : "ic_breakfast";
                    case "Elevator":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_elevator.png" : "ic_elevator";
                    case "Free Wi-fi":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_wifi.png" : "ic_wifi";
                    case "Green":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_green.png" : "ic_green";
                    case "Air conditioning":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_air_conditioning.png" : "ic_air_conditioning";
                    case "Fitness centre":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_fitness_centre.png" : "ic_fitness_centre";
                    case "Dryer":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_dryer.png" : "ic_dryer";
                    case "Indoor fireplace":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_indoor_fireplace.png" : "ic_indoor_fireplace";
                    case "Gym":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_gym.png" : "ic_gym";
                    case "Hot tub":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_hot_tub.png" : "ic_hot_tub";
                    case "Laptop workspace":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_table.png" : "ic_table";
                    case "Parking":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_parking.png" : "ic_parking";
                    case "Swimming pool":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_pool.png" : "ic_pool";
                    case "TV":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_tv.png" : "ic_tv";
                    case "Wheelchair accessible":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_wheelchair_accessible.png" : "ic_wheelchair_accessible";
                    case "Work Table":
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_table.png" : "ic_table";
                    default:
                        // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
                        return Device.RuntimePlatform == Device.UWP ? "Assets/ic_green.png" : "ic_green";
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}