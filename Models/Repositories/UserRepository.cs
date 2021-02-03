using BikeService.Models.Database;
using BikeService.Models.Interfaces;
using BikeService.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace BikeService.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UserRepository(DatabaseContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void AddUser(AppUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }



        public void EditUser(AppUser user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public IList<string> GetRole(AppUser user)
        {
            var role = _userManager.GetRolesAsync(user).Result;
            return role;
        }

        public List<AppUser> Users()
        {
            var userStore = new UserStore<AppUser>(_context);
            return userStore.Users.ToList();
        }
        public AppUser GetUser(string username)
        {
            return _userManager.FindByNameAsync(username).Result;
        }

        public void SetNewRole(AppUser user, string role)
        {
            var Role = _context.Roles.FirstOrDefault(x => x.Name == role);
            var UserRoles = _context.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
            _context.UserRoles.Remove(UserRoles);
            _context.SaveChanges();
            UserRoles.RoleId = Role.Id;
            _context.UserRoles.Add(UserRoles);
            _context.SaveChanges();
        }
        public void  DeleteUser(AppUser user)
        {
            var UserRoles = _context.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
            var User = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            _context.UserRoles.Remove(UserRoles);
            _context.Users.Remove(User);
            _context.SaveChanges();
        }
    }
}
