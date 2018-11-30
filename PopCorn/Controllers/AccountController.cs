using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopCorn.BusinessLayer.Services;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Models;
using PopCorn.Models;

namespace PopCorn.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserService _userService;
		private readonly TypeService _typeService;

		public AccountController(UserService userService, TypeService typeService)
		{
			_userService = userService;
			_typeService = typeService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var user = _userService.GetUser(model.Email, model.Password);
				if (user != null)
				{
					await Authenticate(model.Email);

					return RedirectToAction("Index", "Project");
				}

				ModelState.AddModelError("", "Некорректные логин и(или) пароль");
			}

			return View(model);
		}

		private async Task Authenticate(string userName)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
			};

			var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
				ClaimsIdentity.DefaultRoleClaimType);
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Login", "Account");
		}

		[Authorize]
		public IActionResult Users()
		{
			ViewBag.TableTypeStructure = _typeService.GetTypeStructure(typeof(User), typeof(TableView));
			return View(_userService.GetUsers());
		}

		[Authorize]
		public IActionResult EditUser(int? id)
		{
			ViewBag.FormTypeStructure = _typeService.GetTypeStructure(typeof(User), typeof(InputView));
			return View(id.HasValue ? _userService.GetUser(id.Value) : new User());
		}

		[Authorize]
		[HttpPost]
		public IActionResult EditUser(User user)
		{
			if (_userService.Edit(user))
			{
				return RedirectToAction("Users");
			}

			ModelState.AddModelError("", "Некорректные логин и(или) пароль");

			return View(user);
		}
	}
}