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
            if (parcelnum == null)
            {
                return BadRequest();
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
                return BadRequest();
            }
            else
            {
                ViewBag.MyRouteId = parcel.Id;

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

        //Prints the search certificate
        public FileResult CreatePdf(string parcelnum)
        {
            DocPrinter pdfprinter = new DocPrinter(_context, _hostingEnvironment);
            return pdfprinter.CreatePdf(parcelnum);
        }     

    






    }

}
