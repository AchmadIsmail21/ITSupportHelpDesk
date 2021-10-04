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
<<<<<<< HEAD
       
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


=======
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email tidak boleh kosong")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email Not Valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Minimal Password 6 and Maximal Password 50", MinimumLength = 6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Birht Date is required")]
        public DateTime BirhtDate { get; set; }
>>>>>>> main
        public enum Gender
        {
            Male,
            Female
        }
<<<<<<< HEAD
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

   
=======
        [Required(ErrorMessage = "Gender is required")]
        [Range(0, 1)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender gender { get; set; }
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Number Phone is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Company is required")]
        public string Company { get; set; }
>>>>>>> main
    }
}
