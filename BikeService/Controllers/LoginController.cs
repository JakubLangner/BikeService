using BikeService.Models;
using BikeService.ViewModels.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BikeService.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;


		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View(new LoginVM());
		}

		[HttpPost]
		public async Task<JsonResult> Login(LoginVM model)
		{
			try
			{

				var user = await _userManager.FindByEmailAsync(model.Email);

				if (user == null)
				{
					return Json(new { result = false, message = "Nie znaleziono użytkownika!" });
				}
				else
				{
					var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
					if (result.Succeeded)
					{
						HttpContext.Session.SetString("_UserName", user.FirstName + ' ' + user.LastName);
						HttpContext.Session.SetString("_UserImg", user.ImagePath);
						return Json(new { result = true });
					}
					else
					{
						return Json(new { result = false, message = "Email lub hasło są nieprawidłowe!" });
					}
				}
			}
			catch (Exception e)
			{

				return new JsonResult(false, new { message = e.Message });
			}
		}

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
