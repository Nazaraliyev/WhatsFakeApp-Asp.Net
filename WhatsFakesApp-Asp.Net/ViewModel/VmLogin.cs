using System.ComponentModel.DataAnnotations;

namespace WhatsFakesApp_Asp.Net.ViewModel
{
	public class VmLogin
	{
		[MaxLength(100), Required, EmailAddress]
		public string Mail { get; set; }


		[MaxLength(100), Required]
		public string Password { get; set; }
	}
}
