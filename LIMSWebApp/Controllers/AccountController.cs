using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIMSWebApp.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LIMSWebApp.Controllers
{
   
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
        
        [Authorize]
        [Route("/Home/Services")]
        public IActionResult UserProfile()
        {
            return View();
        }
       
    }
   
}