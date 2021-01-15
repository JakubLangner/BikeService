using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.ViewModels.Admin
{
    public class UsersViewModel
    {
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        [Display(Name = "Adres mailowy")]
        public string Email { get; set; }
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        [NotMapped]
        public List<string> Role { get; set; }
        [NotMapped]
        [Display(Name = "Role")]
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
