﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LIMSWebApp.ViewModels.PropertiesViewModels;
using LIMSInfrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace LIMSWebApp.Controllers
{
	[Authorize]
    public class PropertiesController : Controller
    {
        private readonly LIMSCoreDbContext _limscontext;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly LIMSCoreDbContext _usercontext;

        public PropertiesController(LIMSCoreDbContext limscontext, LIMSCoreDbContext usercontext, IHostingEnvironment hostingEnv)
        {
            _limscontext = limscontext;
            _hostingEnv = hostingEnv;
            _usercontext = usercontext;

        }

        [Route("/my-properties")]
        public ActionResult Properties()
        {
            var username = HttpContext.User.Identity.Name;

            var user = _usercontext.Users.SingleOrDefault(p => p.UserName == username);

            //query parcels that match property ownership creteria

            var owner = _limscontext.Owner.FirstOrDefault(o => o.PIN == user.KRAPIN);

            var parcelsowned = new List<PropertiesViewModel>();

            if (owner != null)
            {
                parcelsowned = _limscontext.Parcel
                .Where(i => i.OwnerId == owner.OwnerId)
                .Select(a => new PropertiesViewModel
                {
                    ParcelNum = a.ParcelNum,
                    TenureType = a.Tenure.TenureType,
                    Rate = a.Rate.Amount,
					Invoices = a.Invoices
					
                }).ToList();
            }
            else
            {
                return View(new List<PropertiesViewModel>());
            }

            return View(parcelsowned);
        }



        // GET: Properties
        public ActionResult AllProperties()
        {
            var parcels = _limscontext.Parcel
                .Include(a => a.Administration)
                .Include(b => b.LandUse)
                .Include(c => c.Owner)
                .Include(d => d.Restriction)
				.Include(d => d.Responsibility)
                .Include(d => d.Valuation)
                .ToList();

            return View();
        }

        // GET: Properties/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(AllProperties));
            }
            catch
            {
                return View();
            }
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Properties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(AllProperties));
            }
            catch
            {
                return View();
            }
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Properties/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(AllProperties));
            }
            catch
            {
                return View();
            }
        }
    }
}
