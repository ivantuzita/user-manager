using System.ComponentModel.DataAnnotations;

namespace UserManager.BlazorUI.Models.Authentication; 
public class UserVM {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public string ReturnUrl { get; set; }
}
