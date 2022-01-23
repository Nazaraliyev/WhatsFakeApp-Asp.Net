using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
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
		private readonly IWebHostEnvironment _webHost;

		public AccountController(AppDbContext context, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, IWebHostEnvironment webHost)
			
		{
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
			_webHost = webHost;
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
			if(await _userManager.FindByEmailAsync(model.Mail) != null)
			{
				ModelState.AddModelError("", "You can not use this Username");
				return View(model);
			}
			if(model.ProfileFile != null)
			{

				if(model.ProfileFile.ContentType == "image/jpeg" || model.ProfileFile.ContentType == "image/png")
				{
					if (model.ProfileFile.Length > 3145728)
					{
						ModelState.AddModelError("", "You can only upload image until 3mb");
						return View(model);
					}

					string fileName = Guid.NewGuid() + "-" + model.ProfileFile.FileName;
					string filePath = Path.Combine(_webHost.WebRootPath, "assets/img/profiles", fileName);
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						model.ProfileFile.CopyTo(stream);
					}
					model.Profile = fileName;
				}
				else
				{
					ModelState.AddModelError("", "You can only upload Image file");
					return View(model);
				}
			}
			CustomUser user = new CustomUser()
			{
				Fullname = model.Fullname,
				Email = model.Mail,
				UserName = model.Mail,
				Profile = model.Profile
			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				await _signInManager.SignInAsync(user, false);

				Random random = new Random();
				int ConfirmNum = random.Next(1000,9999);
				HttpContext.Session.SetString("Confirm", ConfirmNum.ToString());

				MailMessage mail = new MailMessage();
				mail.From = new MailAddress("nzr.testmail@gmail.com", "Confirm Mail");
				mail.To.Add(model.Mail);
				mail.Subject = "Welcome WhatsFake App";
				mail.Body = "Your Confirm Code is " + ConfirmNum;

				SmtpClient client = new SmtpClient();
				client.Host = "smtp.gmail.com";
				client.Port = 587;
				client.EnableSsl = true;
				client.Credentials = new NetworkCredential("nzr.testmail@gmail.com", "Test12345!");


				client.Send(mail);

				return RedirectToAction("Confirm");
			}
			return View();
		}



		public IActionResult Confirm()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Confirm(VmConfirm model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			if(HttpContext.Session.GetString("Confirm") != model.Code)
			{
				ModelState.AddModelError("","Code is not correct");
				return View(model);
			}

			return RedirectToAction("Index", "Home");
		}
	}
}
