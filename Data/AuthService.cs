// AuthService.cs
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace LogIn.Services
{
    public class AuthService : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser;

        public ClaimsPrincipal CurrentUser => _currentUser;

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_currentUser ?? new ClaimsPrincipal(new ClaimsIdentity())));
        }

        public void MarkUserAsAuthenticated(string username)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "CustomAuth"));
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void MarkUserAsLoggedOut()
        {
            _currentUser = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var authState = await GetAuthenticationStateAsync();
            return authState.User.Identity.IsAuthenticated;
        }

        public string GetUsername()
        {
            return _currentUser?.Identity?.Name ?? "Misafir";
        }
    }
}
