using SmartHotel.Clients.Core.Helpers;
using SmartHotel.Clients.Core.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            //NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            CustomMessagingCenter.Subscribe<LoginViewModel>(this, MessengerKeys.SignInRequested, OnSignInRequested);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            StatusBarHelper.Instance.MakeTranslucentStatusBar(true);
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
        }

        void OnSignInRequested(LoginViewModel loginViewModel)
        {
            if(!loginViewModel.IsValid)
            {
                VisualStateManager.GoToState(UsernameEntry, "Invalid");
                VisualStateManager.GoToState(PasswordEntry, "Invalid");
            }
        }
    }
}