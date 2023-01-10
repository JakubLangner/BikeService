using Microsoft.AspNetCore.Identity;

namespace BikeService.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
    }
}
