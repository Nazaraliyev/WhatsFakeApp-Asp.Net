using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WhatsFakesApp_Asp.Net.Hubs
{
    public class ChatHUB:Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
