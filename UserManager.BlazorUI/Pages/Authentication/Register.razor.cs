using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using UserManager.BlazorUI.Interfaces;
using UserManager.BlazorUI.Models.Authentication;

namespace UserManager.BlazorUI.Pages.Authentication;
public partial class Register {
    public RegisterVM Model { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    IToastService toastService { get; set; }
    public string Message { get; set; }
    public string PasswordConfirm { get; set; }
    [Inject]
    private IAuthenticationService AuthenticationService { get; set; }

    protected async Task HandleRegister() {
        if (PasswordConfirm != Model.Password) {
            toastService.ShowError("Your password does not match!");
        }
        else {
            var result = await AuthenticationService.RegisterAsync(Model.FirstName, Model.LastName, Model.Username, Model.Email, Model.Password, Model.Cpf);

            if (result.Errors.IsNullOrEmpty()) {
                toastService.ShowSuccess($"Successfully registered user {Model.Username}!");
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
        Model = new RegisterVM();
    }
}