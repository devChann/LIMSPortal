﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LIMSCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using LIMSWebApp.ViewModels;

namespace LIMSWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult Maps()
        {
            return View();
        }

        public IActionResult Services()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult FAQs()
        {
            ViewData["Message"] = "FAQs Coming soon...";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Profile()
        {
            return View();
        }
    }
}
