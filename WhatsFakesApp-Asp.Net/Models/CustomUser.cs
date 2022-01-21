using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsFakesApp_Asp.Net.Models
{
	public class CustomUser:IdentityUser
	{
		[MaxLength(100), Required]
		public string Fullname { get; set; }


		[MaxLength(250)]
		public string Profile { get; set; }



		[NotMapped]
		public IFormFile ProfileFile { get; set; }
	}
}
