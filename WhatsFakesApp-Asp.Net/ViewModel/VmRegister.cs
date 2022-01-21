using System.ComponentModel.DataAnnotations;

namespace WhatsFakesApp_Asp.Net.ViewModel
{
	public class VmRegister
	{
		[MaxLength(100)]
		public string Fullname { get; set; }



		[MaxLength(100), Required, EmailAddress]
		public string Mail { get; set; }



		[MaxLength(100), Required]
		public string Password { get; set; }


		[MaxLength(100), Required, Compare("Password")]
		public string CoPassword { get; set; }
	}
}
