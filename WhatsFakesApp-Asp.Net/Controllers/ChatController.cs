using Microsoft.AspNetCore.Mvc;

namespace WhatsFakesApp_Asp.Net.Controllers
{
	public class ChatController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
