using System.ComponentModel.DataAnnotations;

namespace WhatsFakesApp_Asp.Net.ViewModel
{
	public class VmConfirm
	{
		[Required, StringLength(4)]
		public string Code { get; set; }
	}
}
