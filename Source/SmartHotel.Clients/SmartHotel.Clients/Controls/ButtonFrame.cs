using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Controls
{
    public class ButtonFrame : Frame
    {
        public ButtonFrame() => HasShadow = true;

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ContentProperty.PropertyName)
            {
                ContentUpdated();
            }
        }

        void ContentUpdated()
        {
            if (DeviceInfo.Platform != DevicePlatform.WinUI)
            {
                return;
            }
            {
                BackgroundColor = Content.BackgroundColor;
            }
        }
    }
}
