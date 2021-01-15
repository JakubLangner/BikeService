using BikeService.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models.Interfaces
{
    public interface IUserRepository
    {
        public List<AppUser> Users();
        public IList<string> GetRole(AppUser user);
        public AppUser GetUser(string username);
        public void SetNewRole(AppUser user, string role);
        public void AddUser(AppUser user);
        public void EditUser(AppUser user);
        public void DeleteUser(AppUser user);
    }
}
