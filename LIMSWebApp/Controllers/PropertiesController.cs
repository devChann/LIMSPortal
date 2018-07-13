using System;
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
using Microsoft.AspNetCore.Authorization;

namespace LIMSWebApp.Controllers
{
    [Authorize]
    public class PropertiesController : Controller
    {
        private readonly LIMSCoreDbContext _limscontext;
        private readonly IHostingEnvironment _hostingEnv;
        private readonly ApplicationDbContext _usercontext;

        public PropertiesController(LIMSCoreDbContext limscontext, ApplicationDbContext usercontext, IHostingEnvironment hostingEnv)
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
                .Where(i => i.OwnerId == owner.Id)
                .Select(a => new PropertiesViewModel
                {
                    ParcelNum = a.ParcelNum,
                    TenureType = a.Tenure.TenureType,
                    Rate = a.Rate.Amount
                }).ToList();
            }
            else
            {
                return View(new List<PropertiesViewModel>());
            }

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