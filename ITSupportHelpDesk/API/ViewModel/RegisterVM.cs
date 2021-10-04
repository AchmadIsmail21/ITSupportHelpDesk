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


        public string NamaLengkap { get; set; }
        [Required(ErrorMessage = "NIK Harus di Isi")]
        public string Id { get; set; }
        [Required(ErrorMessage = "First Name Harus di Isi")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Harus di Isi")]
        public string LastName { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Password tidak boleh kosong")]

        public string Password { get; set; }

        [Phone(ErrorMessage = "Phone Number Name Harus di Isi")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "BirthDate Harus diisi")]
        public string Address { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public int RoleId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }

        //public int Gender
        //{
        //    Male,
        //    Female
        //}
        //[Required, Range(0, 1, ErrorMessage = "Gender harus diantara 0 atau 1")]
        //[JsonConverter(typeof(StringEnumConverter))]



        //public ICollection<User> Users { get; set; }



    }
}

