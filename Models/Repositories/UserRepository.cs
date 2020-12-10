using BikeService.Models.Database;
using BikeService.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
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
        public UserRepository(DatabaseContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
        }

        public void AddUser(AppUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(AppUser user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void EditUser(AppUser user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public List<IdentityRole> Roles()
        {
            return _context.Roles.ToList();
        }

        public List<AppUser> Users()
        {
            return _context.Users.ToList();
        }

    }
}
