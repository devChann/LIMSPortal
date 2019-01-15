using System;
using System.Linq;
using System.Threading.Tasks;
using LIMSWebApp.ViewModels.LIMSViewModels;
using LIMSInfrastructure.Data;
using LIMSInfrastructure.Services.Printing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LIMSWebApp.Extensions;
using System.Collections.Generic;
using LIMSWebApp.Helpers;
using LIMSInfrastructure.Identity;

namespace LIMSWebApp.Controllers
{
	[Authorize]
	public partial class ParcelsIndexController : Controller
	{
		private readonly LIMSCoreDbContext _context;
		private readonly IHostingEnvironment _hostingEnvironment;
		

		public ParcelsIndexController(LIMSCoreDbContext context, IHostingEnvironment hostingEnvironment)
		{
			_context = context;
			_hostingEnvironment = hostingEnvironment;			
		}

		//Renders the search page
		[Route("/parcel-search")]
		public IActionResult Search()
		{
			return View();
		}

		//Renders the search results
		[HttpGet]
		[Route("/parcel-details")]
		public IActionResult SearchParcel(string parcelnum)
		{
			var username = HttpContext.User.Identity.Name;

			var user = _context.Users.SingleOrDefault(p => p.UserName == username);

			ViewData["UserPIN"] = user.KRAPIN;

			if (parcelnum == null)
			{
				return BadRequest();
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
				return BadRequest();
			}
			else
			{
				ViewBag.MyRouteId = parcel.ParcelId;

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

			return View(parcelviewmodel);
		}

		//Prints the search certificate
		public FileResult CreatePdf(string parcelnum)
		{
			var pdfprinter = new DocPrinter(_context, _hostingEnvironment);
			return pdfprinter.CreatePdf(parcelnum);
		}








	}

}
