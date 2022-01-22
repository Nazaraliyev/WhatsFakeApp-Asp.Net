using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsFakesApp_Asp.Net.Models
{
	public class ChatMessage
	{
		[Key]
		public int Id { get; set; }


		[MaxLength(2000), Required]
		public string Content { get; set; }


		[Required]
		public DateTime CreatedTime { get; set; }


		public string SenderId { get; set; }

		public string ReceiverId { get; set; }
	}
}
