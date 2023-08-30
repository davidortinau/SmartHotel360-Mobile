using SmartHotel.Clients.Core.Models;
using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Converters
{
    public class SuggestionTypeToColorConverter : IValueConverter
    {
        readonly Color restaurantColor = Color.FromArgb("#BD4B14");
        readonly Color eventColor = Color.FromArgb("#348E94");
        readonly Color noColor = Color.FromArgb("#FFFFFF");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SuggestionType suggestionType)
            {
                switch (suggestionType)
                {
                    case SuggestionType.Event:
                        return eventColor;
                    case SuggestionType.Restaurant:
                        return restaurantColor;
                }
            }


            return noColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}