using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhatsFakesApp_Asp.Net.Data;
using WhatsFakesApp_Asp.Net.Models;
using WhatsFakesApp_Asp.Net.ViewModel;

namespace WhatsFakesApp_Asp.Net.Controllers
{
	public class AccountController : Controller
	{
		private readonly AppDbContext _context;
		private readonly UserManager<CustomUser> _userManager;
		private readonly SignInManager<CustomUser> _signInManager;

		public AccountController(AppDbContext context, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
		{
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(VmLogin model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = await _signInManager.PasswordSignInAsync(model.Mail, model.Password, false, false);

			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "Login or Password is not correct");
				return View(model);
			}

			return RedirectToAction("Index", "Home");
		}




		public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Register(VmRegister model)
		{
			if(!ModelState.IsValid) return View(model);
			CustomUser user = new CustomUser()
			{
				Fullname = model.Fullname,
				Email = model.Mail,
				UserName = model.Mail,
			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				await _signInManager.SignInAsync(user, false);
				return RedirectToAction("Index", "Home");
			}
			return View();
		}
	}
}
