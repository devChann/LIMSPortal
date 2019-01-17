using LIMSInfrastructure.Data;
using LIMSInfrastructure.Identity;
using LIMSInfrastructure.Services.GeoServices;
using LIMSWebApp.Helpers;
using LIMSWebApp.ViewModels.LIMSViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LIMSWebApp.Controllers
{
    [Authorize]
    public partial class LandController : Controller
    {
        private readonly LIMSCoreDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
		private readonly IGeoService _geoService;
		private readonly LIMSCoreDbContext _usercontext;

        public LandController(LIMSCoreDbContext context, LIMSCoreDbContext usercontext, IHostingEnvironment hostingEnvironment, IGeoService geoService)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
			_geoService = geoService;
			_usercontext = usercontext;
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
        public IActionResult ParcelDetails(string parcelnum)
        {
            var username = HttpContext.User.Identity.Name;

            var user = _usercontext.Users.SingleOrDefault(p => p.UserName == username);

            ViewData["UserPIN"] = user.KRAPIN;

            if (parcelnum == null)
            {
				Response.StatusCode = 404;
				return View("ProductNotFound");
			}

            var parcelviewmodel = new ParcelSearchViewModel(); 

            var parcel = _context.Parcel
                .Include(i => i.Administration)
                .Include(i => i.LandUse)
                .Include(i => i.Registration)
                .Include(i => i.Restriction.Charge)
                .Include(i => i.Restriction.Mortgage)
                .Include(i => i.SpatialUnit)
                .Include(i => i.Tenure)
                .Include(p => p.Payments)
                .Include(i => i.Valuation)
                .Include(i => i.Owner)
                
                .Where(a => a.ParcelNum == parcelnum).SingleOrDefault();

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
                parcelviewmodel.Payments = parcel.Payments;
                parcelviewmodel.RegistrationDate = parcel.Registration.RegistrationDate;
            }

			var geodata = _geoService.GetLandParcel("Parcels", "Parcel_Num", parcelnum);			

			ViewData["Parcel"] = geodata;

			return View(parcelviewmodel);
        }

		//[HttpGet("[action]/{featurename}/{attribute}/{filter}")]
		//[Route("/parcel-geometry")]
		//public IActionResult ParcelGeometry(string featurename,string attribute,string filter)
		//{
		//	var geodata = _geoService.GetLandParcel(featurename, attribute, filter);

		//	return Json(geodata);
		//}

		[Route("/edit-parcel")]
		public IActionResult EditParcel(string parcelnum)
		{

			var parcel = new ParcelSearchViewModel
			{
				ParcelNumber = "12121"
			};

			return View(parcel);
		}

		[Route("/delete-parcel")]
		public IActionResult DeleteParcel(string parcelnum)
		{			

			return RedirectToAction("ListParcels");
		}

		[Route("/parcels")]
		public IActionResult ListParcels()
		{
			var parcels = new List<ParcelSearchViewModel> {

			
			};

			return View(parcels);
		}

		[HttpGet]
		[Route("/add-parcel")]
		public IActionResult AddParcel()
		{
			// add parcels to database

			return View();
		}

		[HttpPost]
		[Route("/add-parcel")]
		public IActionResult AddParcel([Bind]ParcelSearchViewModel parcel)
		{
			// add parcels to database

			return View();
		}

		//Prints the search certificate
        public FileResult CreatePdf(string parcelnum)
        {
            var pdfprinter = new DocPrinter(_context, _hostingEnvironment);
            return pdfprinter.CreatePdf(parcelnum);
        }     

 
    }

}
