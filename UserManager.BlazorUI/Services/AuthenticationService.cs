using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using UserManager.BlazorUI.Interfaces;
using UserManager.BlazorUI.Providers;
using UserManager.BlazorUI.Services.Base;

namespace UserManager.BlazorUI.Services;
public class AuthenticationService : BaseHttpService, IAuthenticationService {
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    public AuthenticationService(IClient client,
        ILocalStorageService localStorage,
        AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage) {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string email, string password) {
        try {
            AuthRequest authenticationRequest = new AuthRequest() { Email = email, Password = password };
            var authenticationResponse = await _client.LoginAsync(authenticationRequest);
            if (authenticationResponse.Token != string.Empty) {
                await _localStorage.SetItemAsync("token", authenticationResponse.Token);

                // Set claims in Blazor and login state
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
                return true;
            }
            return false;
        }
        catch (Exception) {
            return false;
        }

    }
    public async Task Logout() {
        // remove claims in Blazor and invalidate login state
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
    }

    public async Task<RegistrationResponse> RegisterAsync(string firstName, string lastName, string userName, string email, string password, string cpf) {
        if (userName.Length < 6) {
            return new RegistrationResponse { Errors = "Username is too short! Must be at least 6 characters long." };
        }

        RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, UserName = userName, LastName = lastName, Email = email, Password = password, Cpf = cpf };
        var response = await _client.RegisterAsync(registrationRequest);

        return response;
    }

    public async Task<PasswordChangeResponse> PasswordChangeAsync(string username, string currentPassword, string newPassword) {
        PasswordChangeRequest passChangeRequest = new PasswordChangeRequest() { Username = username, CurrentPassword = currentPassword, NewPassword = newPassword};
        var response = await _client.ChangepasswordAsync(passChangeRequest);

        return response;
    }

}