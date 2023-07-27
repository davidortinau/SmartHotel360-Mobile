using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Services.OpenUri
{
    public class OpenUriService : IOpenUriService
    {
        public void OpenUri(string uri) => Device.OpenAsync(new Uri(uri));

        public void OpenSkypeBot(string botId) => Device.OpenAsync(new Uri(string.Format("skype:28:{0}?chat", botId)));
    }
}
