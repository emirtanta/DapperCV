﻿using Microsoft.AspNetCore.Mvc;

namespace DapperCV.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
