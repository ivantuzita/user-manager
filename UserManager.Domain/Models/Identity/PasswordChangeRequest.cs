namespace UserManager.Domain.Models.Identity {
    public class PasswordChangeRequest {
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
