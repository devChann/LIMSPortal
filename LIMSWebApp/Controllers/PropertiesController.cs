﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LIMSWebApp.ViewModels.PropertiesViewModesl;
using LIMSInfrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using LIMSInfrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace LIMSWebApp.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly LIMScoreContext _limscontext;      
        private readonly IHostingEnvironment _hostingEnv;
        private readonly ApplicationDbContext _usercontext;

        public PropertiesController(LIMScoreContext limscontext, ApplicationDbContext usercontext, IHostingEnvironment hostingEnv)
        {
            _limscontext = limscontext;          
            _hostingEnv = hostingEnv;
            _usercontext = usercontext;

        }      

       [Route("/Properties")]
        public ActionResult Properties()
        {
            var username = HttpContext.User.Identity.Name;

            var user = _usercontext.Users.SingleOrDefault(p => p.UserName == username);

            //query parcels that match property ownership creteria

            var owner = _limscontext.Owner.SingleOrDefault(o => o.Pin == user.KRAPIN);

            var parcelsowned = _limscontext.Parcel
                .Where(i => i.OwnerId == owner.Id)
                .Select(a => new PropertiesViewModel
                {
                    ParcelNum = a.ParcelNum,
                    TenureType = a.Tenure.TenureType
                }).ToList();

  
            return View(parcelsowned);
        }



        // GET: Properties
        public ActionResult Index()
        {
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

                return RedirectToAction(nameof(Index));
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

                return RedirectToAction(nameof(Index));
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

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}