using Windows.UI;

namespace SmartHotel.Clients.UWP.Extensions
{
    static class ColorExtensions
    {
        public static Color ToUwp(this Xamarin.Forms.Color color) => Color.FromArgb((byte)(color.Alpha * 255),      
            (byte)(color.Red * 255),
            (byte)(color.Green * 255),
            (byte)(color.Blue * 255));
    }
}
