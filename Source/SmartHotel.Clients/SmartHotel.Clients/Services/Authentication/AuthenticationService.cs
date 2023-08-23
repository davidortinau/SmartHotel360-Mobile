namespace SmartHotel.Clients.Core.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IBrowserCookiesService browserCookiesService;
        readonly IAvatarUrlProvider avatarProvider;

        public AuthenticationService(
            IBrowserCookiesService browserCookiesService,
            IAvatarUrlProvider avatarProvider)
        {
            this.browserCookiesService = browserCookiesService;
            this.avatarProvider = avatarProvider;
        }

        public bool IsAuthenticated => AppSettings.User != null;

        public Models.User AuthenticatedUser => AppSettings.User;

        public Task<bool> LoginAsync(string email, string password)
        {
            var user = new Models.User
            {
                Email = email,
                Name = email,
                LastName = string.Empty,
                AvatarUrl = avatarProvider.GetAvatarUrl(email),
                Token = email,
                LoggedInWithMicrosoftAccount = false
            };

            AppSettings.User = user;

            return Task.FromResult(true);
        }

        public async Task<bool> LoginWithMicrosoftAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserIsAuthenticatedAndValidAsync()
        {
            if (!IsAuthenticated)
            {
                return false;
            }
            else if (!AuthenticatedUser.LoggedInWithMicrosoftAccount)
            {
                return true;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task LogoutAsync()
        {
            AppSettings.RemoveUserData();
            await browserCookiesService.ClearCookiesAsync();
        }
    }
}