using LIMS.Infrastructure.Data;
using LIMS.Infrastructure.Identity;
using LIMS.Infrastructure.Services.GeoServices;
using LIMS.Infrastructure.Services.Properties;
using LIMS.WebApp.Helpers;
using LIMS.WebApp.ViewModels.LIMSViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMS.WebApp.Controllers
{
    [Authorize]
    public partial class LandController : Controller
    {
        private readonly LIMSCoreDbContext _context;
        private readonly IHostEnvironment _hostingEnvironment;
		private readonly IGeoService _geoService;
		private readonly IParcelService _parcelService;

		public LandController(LIMSCoreDbContext context, IHostEnvironment hostingEnvironment,
			IGeoService geoService, IParcelService parcelService)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
			_geoService = geoService;
			_parcelService = parcelService;
		}

        //Renders the search page
        [HttpGet]
        [Route("/parcel-search")]
        public IActionResult Search()
        {
            return View();
        }

        //Renders the search results        
        [Route("/parcel-details")]
        public async Task<IActionResult> ParcelDetails(string parcelnum)
        {
            var username = HttpContext.User.Identity.Name;

            var user = _context.Users.SingleOrDefault(p => p.UserName == username);

            ViewData["UserPIN"] = user.KRAPIN;

            if (parcelnum == null)
            {
				Response.StatusCode = 404;
				return View("ProductNotFound");
			}

            var parcelviewmodel = new ParcelSearchViewModel();
			var parcel = await _parcelService.GetParcelByNumber(parcelnum);           

            if (parcel == null)
            {
				Response.StatusCode = 404;
				return View("ProductNotFound");
			}
            else
            {
                ViewBag.MyRouteId = parcel.ParcelNum;

                parcelviewmodel.ID = parcel.ParcelId;
                parcelviewmodel.ParcelNumber = parcel.ParcelNum;
                parcelviewmodel.Area = parcel.Area;
                parcelviewmodel.AdministrationArea = parcel.Administration.DistrictName;
                parcelviewmodel.landUse = parcel.LandUse.LandUseType;
                parcelviewmodel.Tenure = parcel.Tenure.TenureType;
                parcelviewmodel.PIN = parcel.Owner.PIN;
                parcelviewmodel.Name = parcel.Owner.Name;
                parcelviewmodel.Phone = parcel.Owner.TelephoneAddress;
                parcelviewmodel.Adress = parcel.Owner.PostalAddress;
                parcelviewmodel.SpatialUnitType = parcel.SpatialUnit.SpatialUnitType;
                parcelviewmodel.ValuationRemarks = parcel.Valuation.Remarks;
                parcelviewmodel.Valuer = parcel.Valuation.Valuer;
                parcelviewmodel.RegistrationType = parcel.Registration.RegistrationType;
                parcelviewmodel.RegistrationSection = parcel.Registration.RegistrationSection;
                parcelviewmodel.MAmount = parcel.Restriction.Mortgage.Amount;
                parcelviewmodel.Lender = parcel.Restriction.Mortgage.Lender;
                parcelviewmodel.amount = parcel.Restriction.Charge.Amount;
                parcelviewmodel.ChargeLender = parcel.Restriction.Charge.Lender;
                parcelviewmodel.Invoices = parcel.Invoices;
                parcelviewmodel.RegistrationDate = parcel.Registration.RegistrationDate;
            }
			var geodata = "";

			try
			{
				geodata =_geoService.GetLandParcel("Parcels", "Parcel_Num", parcelnum);
			}
			catch(Exception e)
			{
				return NotFound(e.Message);
			}
					

			ViewData["Parcel"] = geodata;

			return View(parcelviewmodel);
        }

		

		[Route("/edit-parcel")]
		public IActionResult EditParcel(string parcelnum)
		{
			if (string.IsNullOrWhiteSpace(parcelnum))
			{
				throw new ArgumentException("message", nameof(parcelnum));
			}

			var parcel = new ParcelSearchViewModel
			{
				ParcelNumber = "12121"
			};

			return View(parcel);
		}

		[Route("/delete-parcel")]
		public IActionResult DeleteParcel(string parcelnum)
		{
			if (string.IsNullOrWhiteSpace(parcelnum))
			{
				throw new ArgumentException("message", nameof(parcelnum));
			}

			return RedirectToAction("ListParcels");
		}

		[Route("/parcels")]
		public IActionResult ListParcels()
		{
			var parcels = new List<ParcelSearchViewModel> {
			
			};

			return View(parcels);
		}

		

		//Prints the search certificate
        public FileResult CreatePdf(string parcelnum)
        {
            var pdfprinter = new DocPrinter(_context, _hostingEnvironment);

            return pdfprinter.CreatePdf(parcelnum);
        }     

 
    }

}
