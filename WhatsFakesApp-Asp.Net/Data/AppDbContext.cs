using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhatsFakesApp_Asp.Net.Models;

namespace WhatsFakesApp_Asp.Net.Data
{
	public class AppDbContext:IdentityDbContext
	{
		public AppDbContext(DbContextOptions options):base(options)
		{

		}


		public DbSet<CustomUser> customUsers { get; set; }
		public DbSet<Message> messages { get; set; }
	}
}
