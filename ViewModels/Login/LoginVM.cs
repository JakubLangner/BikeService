using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.ViewModels.Login
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Podanie hasła jest wymagane")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}
