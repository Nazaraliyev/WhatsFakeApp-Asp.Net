using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WhatsFakesApp_Asp.Net.Data;
using WhatsFakesApp_Asp.Net.Models;
using WhatsFakesApp_Asp.Net.ViewModel;

namespace WhatsFakesApp_Asp.Net.ViewComponents
{
	public class VcChatListController : ViewComponent
	{
		private readonly AppDbContext _context;
		private readonly UserManager<CustomUser> _userManager;
		
		public VcChatListController(AppDbContext context, UserManager<CustomUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}
		public IViewComponentResult Invoke()
		{
			string userId = _userManager.GetUserId(HttpContext.User);
			VmChatList model = new VmChatList()
			{
				customUsers = _context.customUsers.Where(c => c.Id != userId).ToList(),
				messages = _context.messages.ToList()
			};
			return View(model);
		}
	}
}
