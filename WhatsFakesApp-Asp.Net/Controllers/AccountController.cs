using Microsoft.AspNetCore.Mvc;

namespace WhatsFakesApp_Asp.Net.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}




		public IActionResult Register()
		{
			return View();
		}
	}
}
