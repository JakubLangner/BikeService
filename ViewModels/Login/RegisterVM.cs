using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.ViewModels.Login
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [Display(Name = "Adres mailowy")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Podanie hasła jest wymagane")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Hasło musi zawierać co najmniej osiem znaków, w tym co najmniej jedną cyfrę, a także małe i wielkie litery oraz znaki specjalne")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Potwierdź hasło")]
        [Display(Name = "Potwierdź hasło")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Hasło musi zawierać co najmniej osiem znaków, w tym co najmniej jedną cyfrę, a także małe i wielkie litery oraz znaki specjalne")]
        public string ConfirmPassword { get; set; }
    }
}
