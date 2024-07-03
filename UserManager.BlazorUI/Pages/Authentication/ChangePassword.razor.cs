using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using UserManager.BlazorUI.Interfaces;
using UserManager.BlazorUI.Models.Authentication;

namespace UserManager.BlazorUI.Pages.Authentication; 
public partial class ChangePassword {
    public ChangePasswordVM Model { get; set; }
    public string Message { get; set; }
    public string PasswordConfirm { get; set; }

    [Inject]
    private IAuthenticationService AuthenticationService { get; set; }
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    IToastService toastService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private async Task HandleChangePassword() {
        if (PasswordConfirm != Model.NewPassword) {
            toastService.ShowError("Your password does not match!");
        }
        else {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var result = await AuthenticationService.PasswordChangeAsync(authState.User?.Identity?.Name, Model.CurrentPassword, Model.NewPassword);
            if (result.Errors.IsNullOrEmpty()) {
                toastService.ShowSuccess($"Succesfully changed your password!");
                NavigationManager.NavigateTo("/");
            }
            else {
                string[] errors = result.Errors.Split(';');

                foreach (string error in errors) {
                    toastService.ShowError(error);
                }
            }
        }

    }

    protected override void OnInitialized() {
        Model = new ChangePasswordVM();
    }
}