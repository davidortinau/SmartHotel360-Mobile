using SmartHotel.Clients.Core.Models;
using SmartHotel.Clients.Core.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Views
{
    public partial class SettingsView : ContentPage
	{
		public SettingsView()
		{
			InitializeComponent ();

            CustomMessagingCenter.Subscribe<SettingsViewModel<RemoteSettings>>(this, MessengerKeys.LoadSettingsRequested, OnLoadSettingsRequested);
        }

        void OnLoadSettingsRequested(SettingsViewModel<RemoteSettings> settingsViewModel)
        {
            if(!settingsViewModel.IsValid)
            {
                VisualStateManager.GoToState(RemoteJsonEntry, "Invalid");
            }
        }
	}
}