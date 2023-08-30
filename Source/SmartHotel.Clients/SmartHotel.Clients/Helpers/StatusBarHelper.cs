using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Helpers
{
    public class StatusBarHelper
    {
        static readonly StatusBarHelper instance = new StatusBarHelper();
        public const string TranslucentStatusChangeMessage = "TranslucentStatusChange";

        public static StatusBarHelper Instance => instance;

        protected StatusBarHelper()
        {
        }

        public void MakeTranslucentStatusBar(bool translucent) => CustomMessagingCenter.Send(this, TranslucentStatusChangeMessage, translucent);
    }
}
