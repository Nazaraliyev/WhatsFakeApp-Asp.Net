using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsFakesApp_Asp.Net.Models
{
	public class Message
	{
		[Key]
		public int Id { get; set; }


		[MaxLength(2000), Required]
		public string Content { get; set; }


		[Required]
		public DateTime CreatedTime { get; set; }



		[ForeignKey("SenderId")]
		public int SenderId { get; set; }
		public CustomUser Sender { get; set; }


		[ForeignKey("ReceiverId")]
		public int ReceiverId { get; set; }
		public CustomUser Receiver { get; set; }
	}
}
