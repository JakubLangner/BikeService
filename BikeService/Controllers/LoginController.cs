using BikeService.Models;
using BikeService.ViewModels.Login;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;


namespace BikeService.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		private readonly IWebHostEnvironment _env;


		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IWebHostEnvironment env)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_env = env;
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

		[HttpPost]
		public async Task<JsonResult> Register(LoginVM model)
		{
			try
			{
				string filePath = "";
				var webRoot = _env.WebRootPath;
				if (model.File != null)
				{
					filePath = Path.Combine(webRoot.ToString() + "\\images\\userImages\\" + model.File.FileName);

					if (model.File.FileName.Length > 0)
					{
						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await model.File.CopyToAsync(stream);
						}
					}
				}
				else
				{
					filePath = "\\images\\userImages\\" + "userDefault.png";
				}

				if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
				{
					return new JsonResult(false, new { message = "Imie, nazwisko, email oraz hasło są obowiązkowe!" });

				}

				var user = new AppUser()
				{
					UserName = model.FirstName + '-'+model.LastName,
					FirstName = model.FirstName,
					LastName = model.LastName,
					Email = model.Email,
					PhoneNumber = model.PhoneNumber ?? "",
					ImagePath = "\\images\\userImages\\" + model.File.FileName
				};

				var result = await _userManager.CreateAsync(user, model.Password);


				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, "User");
					return Json(new { result = true });
				}
				else
				{
					return new JsonResult(false, new { message = "Rejestracja nie powiodła się" });
				}
			}
			catch (Exception e)
			{
				return new JsonResult(false, new { message = e.Message });
			}
		}
	}
}
