using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LIMS.WebApp.ViewModels;
using LIMS.WebApp.Hubs;
using LIMS.Infrastructure.Services.Payment;
using System;
using Microsoft.Extensions.Hosting;
using System.IO;
using LIMS.Infrastructure.Services.GeoServices;
using Microsoft.Extensions.Configuration;
using LIMS.Infrastructure.Services.Properties;

namespace LIMS.WebApp.Controllers
{
	public class HomeController : Controller
    {
        private readonly IHostEnvironment _hostingEnvironment;
		private readonly IParcelService _parcelService;
		private readonly IGeoService _geoService;
		private readonly IConfiguration _configuration;

		public HomeController(IHostEnvironment hostingEnvironment, IParcelService parcelService, IGeoService geoService,IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
			_parcelService = parcelService;
			_geoService = geoService;
			_configuration = configuration;
		}

        public IActionResult Index()
        {		
			return View();
        }

		public IActionResult About()
		{			
			return View();
		}

		[Authorize]
        public IActionResult Maps()
        {
            return View();
        }

        [Authorize]
        [Route("/services")]
        public IActionResult Services()
        {		
            return View();
        }        

        public IActionResult FAQs()
        {
            ViewData["Message"] = "FAQs Coming soon...";

            return View();
        }

        [Route("/terms-and-conditions")]
        public IActionResult Terms()
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
        public IActionResult Error(int? statusCode = null)
        {
            
            if (statusCode.HasValue)
            {
                if (statusCode.Value == 404 || statusCode.Value == 500)
                {
                    var viewName = statusCode.ToString();
                    return View(viewName);
                }
            }            

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
