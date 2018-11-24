using LIMSInfrastructure.Data;
using LIMSInfrastructure.Identity;
using LIMSWebApp.Helpers;
using LIMSWebApp.ViewModels.LIMSViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LIMSWebApp.Controllers
{
    [Authorize]
    public partial class ParcelsController : Controller
    {
        private readonly LIMSCoreDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly LIMSCoreDbContext _usercontext;

        public ParcelsController(LIMSCoreDbContext context, LIMSCoreDbContext usercontext, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
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
                .Include(i => i.RestrictionsNavigation.Chrage)
                .Include(i => i.RestrictionsNavigation.Morgage)
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

                parcelviewmodel.ID = parcel.Id;
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
                parcelviewmodel.MAmount = parcel.RestrictionsNavigation.Morgage.Amount;
                parcelviewmodel.Lender = parcel.RestrictionsNavigation.Morgage.Lender;
                parcelviewmodel.amount = parcel.RestrictionsNavigation.Chrage.Amount;
                parcelviewmodel.ChargeLender = parcel.RestrictionsNavigation.Chrage.Lender;
                parcelviewmodel.Payments = parcel.Payments;
                parcelviewmodel.RegistrationDate = parcel.Registration.RegistrationDate;
            }

            return View(parcelviewmodel);
        }

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
