using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Domain.Models.Identity {
    public class PasswordChangeResponse {
        public bool Success { get; set; }
        public string Errors { get; set; }
    }
}
