using SmartHotel.Clients.Core.Services.Analytic;
using SmartHotel.Clients.Core.ViewModels.Base;
using System.Windows.Input;
using MvvmHelpers.Commands;
using Mopups.Services;

namespace SmartHotel.Clients.Core.ViewModels
{
    public class CheckoutViewModel : ViewModelBase
    {
        readonly IAnalyticService analyticService;

        public CheckoutViewModel(IAnalyticService analyticService) => this.analyticService = analyticService;

        public string UserName => AppSettings.User?.Name;

        public string UserAvatar => AppSettings.User?.AvatarUrl;

        public ICommand ClosePopupCommand => new AsyncCommand(ClosePopupAsync);

        public ICommand CheckoutCommand => new AsyncCommand(CheckoutAsync);

        Task ClosePopupAsync()
        {
            AppSettings.HasBooking = false;

            CustomMessagingCenter.Send(this, MessengerKeys.CheckoutRequested);
            analyticService.TrackEvent("Checkout");

            if (MopupService.Instance.PopupStack.Any())
            {
                return MopupService.Instance.PopAllAsync(true);
            }
            else
            {
                return Task.CompletedTask;
            }
        }

        async Task CheckoutAsync()
        {
            AppSettings.HasBooking = false;

            CustomMessagingCenter.Send(this, MessengerKeys.CheckoutRequested);
            analyticService.TrackEvent("Checkout");            

            if (MopupService.Instance.PopupStack.Any())
            {
                await MopupService.Instance.PopAllAsync(true);
            }

            await NavigationService.NavigateToAsync<BookingViewModel>();
        }
    }
}