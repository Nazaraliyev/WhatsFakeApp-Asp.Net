﻿using Microsoft.AspNetCore.Mvc;

namespace WhatsFakesApp_Asp.Net.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
