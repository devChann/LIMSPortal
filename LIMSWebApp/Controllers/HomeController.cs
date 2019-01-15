using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LIMSWebApp.ViewModels;
using LIMSInfrastructure.Services.Payment;
using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using LIMSInfrastructure.Services.GeoServices;

namespace LIMSWebApp.Controllers
{
	public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
		private readonly IGeoService _geoService;

		public HomeController(IHostingEnvironment hostingEnvironment, IGeoService geoService)
        {
            _hostingEnvironment = hostingEnvironment;
			_geoService = geoService;
		}

        public IActionResult Index()
        {		
            return View();
        }

		public IActionResult About()
		{
			var geodata = _geoService.GetLandParcel("Parcels", "Parcel_Num", "001/BY/4546");

			ViewData["Parcel"] = geodata;
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
