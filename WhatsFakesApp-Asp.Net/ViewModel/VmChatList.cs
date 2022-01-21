using System.Collections.Generic;
using WhatsFakesApp_Asp.Net.Models;

namespace WhatsFakesApp_Asp.Net.ViewModel
{
	public class VmChatList
	{
		public List<CustomUser> customUsers { get; set; }
		public List<ChatMessage> messages { get; set; }
	}
}
