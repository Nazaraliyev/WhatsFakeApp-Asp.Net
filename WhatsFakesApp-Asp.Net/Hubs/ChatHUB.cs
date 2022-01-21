using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WhatsFakesApp_Asp.Net.Hubs
{
    public class ChatHUB:Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
