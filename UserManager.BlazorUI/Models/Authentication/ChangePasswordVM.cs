using System.ComponentModel.DataAnnotations;

namespace UserManager.BlazorUI.Models.Authentication {
    public class ChangePasswordVM {
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
