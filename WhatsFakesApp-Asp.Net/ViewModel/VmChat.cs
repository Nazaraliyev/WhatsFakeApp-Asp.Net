using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Collections.Generic;
using WhatsFakesApp_Asp.Net.Models;

namespace WhatsFakesApp_Asp.Net.ViewModel
{
	public class VmChat
	{
		public CustomUser Receiver { get; set; }
		public List<ChatMessage> messages { get; set; }
	}
}
