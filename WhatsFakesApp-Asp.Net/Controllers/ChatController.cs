using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WhatsFakesApp_Asp.Net.Data;
using WhatsFakesApp_Asp.Net.Models;
using WhatsFakesApp_Asp.Net.ViewModel;

namespace WhatsFakesApp_Asp.Net.Controllers
{
	public class ChatController : Controller
	{
		private readonly AppDbContext _context;
		private readonly UserManager<CustomUser> _userManager;

		public ChatController(AppDbContext context, UserManager<CustomUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}
		public async Task<IActionResult> Index(string Id)
		{
			string senderId = _userManager.GetUserId(User);
			VmChat model = new VmChat()
			{
				Receiver = _context.customUsers.Find(Id),
				messages = _context.messages.Where(m => (m.ReceiverId == Id && m.SenderId == senderId) || (m.ReceiverId == senderId && m.SenderId == Id))
											.ToList()
			};
			return View(model);
		}
	}
}
