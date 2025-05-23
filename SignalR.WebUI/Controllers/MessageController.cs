﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientUserCount()
        {
            return View();
        }
    }
}