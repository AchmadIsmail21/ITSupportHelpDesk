using API.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class LoginVM
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Harus di Isi")]
        // [MinLength(6,ErrorMessage = "Password Minimal 6 Digit")]
        public string Password { get; set; }


        // [Required(ErrorMessage = "New Password Harus di Isi Yang Baru")]
        //[MinLength(6,ErrorMessage = "Password Minimal 6 Digit")]
        public string NewPassword { get; set; }
        public string OTP { get; set; }
        public int RoleId { get; set; }

        public virtual Role Roles { get; set; }
    }
}
