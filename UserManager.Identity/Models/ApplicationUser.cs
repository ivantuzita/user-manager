using Microsoft.AspNetCore.Identity;

namespace UserManager.Identity.Models {
    public class ApplicationUser : IdentityUser {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf {  get; set; }
    }
}
