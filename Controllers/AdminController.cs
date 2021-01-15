using BikeService.Models;
using BikeService.Models.Interfaces;
using BikeService.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IServiceProvider _provider;
        public AdminController(IUserRepository userRepository, UserManager<AppUser> userManager, IServiceProvider provider)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _provider = provider;
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Users()
        {
            var allUsers = new List<UsersViewModel>();
            var users = _userRepository.Users();
            foreach (var user in users)
            {
                var model = new UsersViewModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    Role = new List<string>()
                };
                var roles = _userRepository.GetRole(user);
                foreach (var r in roles)
                {
                    model.Role.Add(r);
                }
                allUsers.Add(model);
            }
            return View(allUsers);
        }

        public IActionResult ConfirmUser(UsersViewModel model)
        {
            var user = _userRepository.GetUser(model.UserName);
            _userRepository.SetNewRole(user,"Service");
            TempData["ConfirmUser"] = "Potwierdziłeś użytkownika";
            return RedirectToAction("Users", "Admin");
        }
        
        public IActionResult DeleteUser(UsersViewModel model)
        { 
            TempData["DeleteUser"] = "Usunąłeś użytkownika";
            var user = _userRepository.GetUser(model.UserName);
            _userRepository.DeleteUser(user);
            
            return RedirectToAction("Users", "Admin");
        }
        [HttpGet]
        public IActionResult EditUser(string username)
        {
            var editUser = _userRepository.GetUser(username);
            var user = new UsersViewModel();
            var role = 
            user.Email = editUser.Email;
            user.UserName = editUser.UserName;
            user.FirstName = editUser.FirstName;
            user.LastName = editUser.LastName;
            user.Roles = new List<SelectListItem>()
            {
                new SelectListItem {Text = "Administrator", Value = "Admin",Selected = _userManager.IsInRoleAsync(editUser, "Admin").Result},
                new SelectListItem {Text = "Service", Value = "Service",Selected = _userManager.IsInRoleAsync(editUser, "Service").Result},
                new SelectListItem {Text = "UnapprovedUser", Value = "UnapprovedUser",Selected = _userManager.IsInRoleAsync(editUser, "UnapprovedUser").Result}
            };
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UsersViewModel model)
        {
            var roleManager = _provider.GetRequiredService<RoleManager<IdentityRole>>();

            AppUser editUser = _userRepository.GetUser(model.UserName);
            editUser.Email = model.Email;
            editUser.UserName = model.UserName;
            editUser.FirstName = model.FirstName;
            editUser.LastName = model.LastName;
            if (model.Role != null)
            {
                IList<string> userRoles = _userManager.GetRolesAsync(editUser).Result;
                foreach (string roleName in userRoles)
                {
                    if (!model.Role.Contains(roleName))
                    {
                        await _userManager.RemoveFromRoleAsync(editUser, roleName);
                    }
                }
                foreach (string role in model.Role)
                {

                    var roleCheck = roleManager.RoleExistsAsync(role).Result;
                    if (roleCheck)
                    {
                        var isInRole = await _userManager.IsInRoleAsync(editUser, role);
                        if (!isInRole)
                        {
                            await _userManager.AddToRoleAsync(editUser, role);
                        }
                    }
                }
            }
            var result = _userManager.UpdateAsync(editUser).Result;
            TempData["EditUser"] = "Edytowałeś użytkownika";
            return RedirectToAction("Users", "Admin");
        }
    }
}
