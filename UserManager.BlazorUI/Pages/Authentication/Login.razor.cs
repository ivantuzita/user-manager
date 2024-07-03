using UserManager.BlazorUI.Interfaces;
using UserManager.BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.Components;
using Blazored.Toast.Services;

namespace UserManager.BlazorUI.Pages.Authentication;
public partial class Login {
    public UserVM Model { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public string Message { get; set; }
    [Inject]
    private IAuthenticationService AuthenticationService { get; set; }
    [Inject]
    IToastService toastService { get; set; }

    protected async Task HandleLogin() {
        if (await AuthenticationService.AuthenticateAsync(Model.Email, Model.Password)) {
            NavigationManager.NavigateTo("/");
            toastService.ShowSuccess($"Welcome, {Model.Email}!");
        }
        else {
            toastService.ShowError("Email or password not recognized!");
        }
        
    }

    protected override void OnInitialized() {
        Model = new UserVM();
    }
}