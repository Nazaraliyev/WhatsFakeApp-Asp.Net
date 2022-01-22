using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using WhatsFakesApp_Asp.Net.Data;
using WhatsFakesApp_Asp.Net.Models;

namespace WhatsFakesApp_Asp.Net.Hubs
{
    public class ChatHUB:Hub
    {
		private readonly AppDbContext _context;
		private readonly UserManager<CustomUser> _userManager;

		public ChatHUB(AppDbContext context,UserManager<CustomUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}
        public async Task SendMessage(string message, string receiver, string sender)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);

            ChatMessage msg = new ChatMessage()
            {
                Content = message,
                SenderId = sender,
                ReceiverId = receiver
			};
            await _context.messages.AddAsync(msg);
            await _context.SaveChangesAsync();
        }
    }
}
