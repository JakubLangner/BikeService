using Microsoft.AspNetCore.Http;

namespace BikeService.ViewModels.Login
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile File { get; set; }
    }
}
