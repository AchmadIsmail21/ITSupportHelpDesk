using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class RegisterVM
    {
       
        [Required(ErrorMessage = "Id Harus di Isi")]
        // [StringLength(9, ErrorMessage = "NIK Harus Terdiri Dari 9 Digit ")]
        public string Id { get; set; }
        [Required(ErrorMessage = "First Harus di Isi")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Harus di Isi")]
        public string LastName { get; set; }
        [Phone(ErrorMessage = "Phone Number Name Harus di Isi")]
        // [StringLength(12,ErrorMessage ="PhoneNumber Harus Terdiri Dari 12 Digit")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Company Harus di Isi")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Company Harus di Isi")]
        public string Company { get; set; }
        [Required(ErrorMessage = "BirthDate Harus diisi")]
        public DateTime BirthDate { get; set; }


        public enum Gender
        {
            Male,
            Female
        }
        public Gender gender { get; set; }
        [Required(ErrorMessage = "Salary Depan tidak boleh kosong")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Email tidak boleh kosong"),
       EmailAddress(ErrorMessage = "Alamat Email tidak valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password tidak boleh kosong")]
        // MinLength(8, ErrorMessage = "Password Minimal 8 Karakter"),
        // RegularExpression("^(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z])(?=\\D*\\d)[^:&.~\\s]{5,20}$", ErrorMessage = "Password harus mengadung huruf besar,huruf kecil dan angka ")]
        public string Password { get; set; }
       
        [Required(ErrorMessage = "RoleId tidak boleh kosong")]
        public int RoleId { get; set; }

   
    }
}
