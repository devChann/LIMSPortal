﻿using System;
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

        public async Task<IActionResult> Index()
        {
            var viewModel = new ParcelsIndexViewModel
            {
                Parcels = await _context.Parcel
                .Include(i => i.Administration)
                .Include(i => i.LandUse)
                .Include(i => i.SpatialUnit)
                .Include(i => i.Tenure)
                .Include(i => i.Valuation)
                .Include(i => i.Owner)
                 .AsNoTracking()
                .OrderBy(i => i.ParcelNum)
                .ToListAsync()
            };


            return View(viewModel);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchParcel(string parcelnum)
        {
            if (parcelnum == null)
            {
                return BadRequest();
            }

            var parcelviewmodel = new ParcelSearchViewModel(); // instance variable
            var parcel = _context.Parcel
                .Include(i => i.Administration)
                .Include(i => i.LandUse)
                .Include(i => i.Registration)
                .Include(i => i.RestrictionsNavigation.Chrage)
                .Include(i => i.RestrictionsNavigation.Morgage)
                .Include(i => i.SpatialUnit)
                .Include(i => i.Tenure)
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

                parcelviewmodel.RegistrationDate = parcel.Registration.RegistrationDate;


            }

            return View(parcelviewmodel);
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DetailsView(int? ID)

        {
            if (ID == null)
            {
                return NotFound();
            }
            var parcels = await _context.Parcel
                .Include(c => c.Administration)
                .Include(c => c.Area)
                .Include(c => c.Owner)
                .Include(c => c.Tenure)
                  .ThenInclude(s => s.Leasehold)
                  .ThenInclude(s => s.LeasePeriod)
                .Include(c => c.Valuation)
                .Include(c => c.SpatialUnit)
                    .ThenInclude(n => n.MapIndex)

                .Include(c => c.Owner)

                .Include(c => c.Registration)
                .Include(c => c.LandUse)
                    .ThenInclude(d => d.Zone)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == ID);

            var model = new ParcelSearchViewModel
            {
                ParcelNumber = parcels.ParcelNum,
                AdministrationArea = parcels.Administration.DistrictName,
                Area = parcels.Area,
                landUse = parcels.LandUse.LandUseType,
                Tenure = parcels.Tenure.TenureType
            };


            if (parcels == null)
            {
                return NotFound();
            }


            return View(model);
        }

        public FileResult CreatePdf(string parcelnum)
        {
            DocPrinter pdfprinter = new DocPrinter(_context, _hostingEnvironment);
            return pdfprinter.CreatePdf(parcelnum);
        }

       

        //[HttpGet("/mapview/{id}")]
        public IActionResult MapView(int id)
        {
            ViewBag.MyRouteId = id;

            return View();
        }

        public async Task<IActionResult> Payments(string parcelnum)
        {
            var ratesmodel = new RatesPaymentViewModel();

            var payments = await _context.Parcel
                .Include(a => a.LandUse)
                .Include(p => p.Administration)
                .Include(p => p.Owner)
                .Include(a => a.Payments)
                .Include(b => b.Rate)
                .SingleOrDefaultAsync(a => a.ParcelNum == parcelnum);
                

            ratesmodel.ParcelNumber = payments.ParcelNum;
            ratesmodel.AdministrationArea = payments.Administration.DistrictName;
            ratesmodel.Area = payments.Area;
            ratesmodel.Id = payments.Id;
            ratesmodel.Name = payments.Owner.Name;
            ratesmodel.Phone = payments.Owner.TelephoneAddress;
            ratesmodel.Adress = payments.Owner.PostalAddress;
            ratesmodel.DateSearched = DateTime.Now;
            ratesmodel.PIN = payments.Owner.PIN;
            ratesmodel.Payments = payments.Payments;
            ratesmodel.LandUse = payments.LandUse.LandUseType;
            ratesmodel.Rate = payments.Rate.Amount;

            return View(ratesmodel);
        }





    }

}
