using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WhatsFakesApp_Asp.Net.Data;
using WhatsFakesApp_Asp.Net.Models;

namespace WhatsFakesApp_Asp.Net.ViewComponents
{
	public class VcSignInUserController : ViewComponent
	{
		private readonly UserManager<CustomUser> _userManager;
		private readonly AppDbContext _context;

		public VcSignInUserController(UserManager<CustomUser> userManager, AppDbContext context)
		{
			_userManager = userManager;
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			string Id = _userManager.GetUserId(HttpContext.User);
			string Profile = _context.customUsers.Find(Id).Profile;
			return View(Profile);
		}
	}
}
