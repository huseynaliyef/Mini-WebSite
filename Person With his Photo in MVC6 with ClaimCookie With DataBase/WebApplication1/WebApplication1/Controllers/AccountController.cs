﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
