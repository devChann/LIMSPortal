using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIMSCore.Entities;
using LIMSInfrastructure.Data;

namespace LIMSWebApp.Controllers
{
    public class Parcels1Controller : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public Parcels1Controller(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Parcels1
        public async Task<IActionResult> Index()
        {
            var lIMSCoreDbContext = _context.Parcel.Include(p => p.Administration).Include(p => p.LandUse).Include(p => p.Owner).Include(p => p.OwnershipRightsNavigation).Include(p => p.Rate).Include(p => p.Registration).Include(p => p.ResponsibilitiesNavigation).Include(p => p.RestrictionsNavigation).Include(p => p.SpatialUnit).Include(p => p.Tenure).Include(p => p.Valuation);
            return View(await lIMSCoreDbContext.ToListAsync());
        }

        // GET: Parcels1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcel
                .Include(p => p.Administration)
                .Include(p => p.LandUse)
                .Include(p => p.Owner)
                .Include(p => p.OwnershipRightsNavigation)
                .Include(p => p.Rate)
                .Include(p => p.Registration)
                .Include(p => p.ResponsibilitiesNavigation)
                .Include(p => p.RestrictionsNavigation)
                .Include(p => p.SpatialUnit)
                .Include(p => p.Tenure)
                .Include(p => p.Valuation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // GET: Parcels1/Create
        public IActionResult Create()
        {
            ViewData["Administrationid"] = new SelectList(_context.Administration, "Id", "Id");
            ViewData["LandUseId"] = new SelectList(_context.LandUse, "Id", "Id");
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "Id");
            ViewData["OwnershipRights"] = new SelectList(_context.OwnershiRights, "Id", "Id");
            ViewData["RateId"] = new SelectList(_context.Rates, "Id", "Id");
            ViewData["RegistrationId"] = new SelectList(_context.Registration, "Id", "Id");
            ViewData["Responsibilities"] = new SelectList(_context.Responsibility, "Id", "Id");
            ViewData["Restrictions"] = new SelectList(_context.Restriction, "Id", "Id");
            ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "Id", "Id");
            ViewData["TenureId"] = new SelectList(_context.Tenure, "Id", "Id");
            ViewData["ValuationId"] = new SelectList(_context.Valution, "Id", "Id");
            return View();
        }

        // POST: Parcels1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Administrationid,Area,LandUseId,OwnerId,OwnershipRights,ParcelNum,RegistrationId,Responsibilities,Restrictions,SpatialUnitId,TenureId,ValuationId,RateId")] Parcel parcel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parcel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Administrationid"] = new SelectList(_context.Administration, "Id", "Id", parcel.Administrationid);
            ViewData["LandUseId"] = new SelectList(_context.LandUse, "Id", "Id", parcel.LandUseId);
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "Id", parcel.OwnerId);
            ViewData["OwnershipRights"] = new SelectList(_context.OwnershiRights, "Id", "Id", parcel.OwnershipRights);
            ViewData["RateId"] = new SelectList(_context.Rates, "Id", "Id", parcel.RateId);
            ViewData["RegistrationId"] = new SelectList(_context.Registration, "Id", "Id", parcel.RegistrationId);
            ViewData["Responsibilities"] = new SelectList(_context.Responsibility, "Id", "Id", parcel.Responsibilities);
            ViewData["Restrictions"] = new SelectList(_context.Restriction, "Id", "Id", parcel.Restrictions);
            ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "Id", "Id", parcel.SpatialUnitId);
            ViewData["TenureId"] = new SelectList(_context.Tenure, "Id", "Id", parcel.TenureId);
            ViewData["ValuationId"] = new SelectList(_context.Valution, "Id", "Id", parcel.ValuationId);
            return View(parcel);
        }

        // GET: Parcels1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcel.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }
            ViewData["Administrationid"] = new SelectList(_context.Administration, "Id", "Id", parcel.Administrationid);
            ViewData["LandUseId"] = new SelectList(_context.LandUse, "Id", "Id", parcel.LandUseId);
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "Id", parcel.OwnerId);
            ViewData["OwnershipRights"] = new SelectList(_context.OwnershiRights, "Id", "Id", parcel.OwnershipRights);
            ViewData["RateId"] = new SelectList(_context.Rates, "Id", "Id", parcel.RateId);
            ViewData["RegistrationId"] = new SelectList(_context.Registration, "Id", "Id", parcel.RegistrationId);
            ViewData["Responsibilities"] = new SelectList(_context.Responsibility, "Id", "Id", parcel.Responsibilities);
            ViewData["Restrictions"] = new SelectList(_context.Restriction, "Id", "Id", parcel.Restrictions);
            ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "Id", "Id", parcel.SpatialUnitId);
            ViewData["TenureId"] = new SelectList(_context.Tenure, "Id", "Id", parcel.TenureId);
            ViewData["ValuationId"] = new SelectList(_context.Valution, "Id", "Id", parcel.ValuationId);
            return View(parcel);
        }

        // POST: Parcels1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Administrationid,Area,LandUseId,OwnerId,OwnershipRights,ParcelNum,RegistrationId,Responsibilities,Restrictions,SpatialUnitId,TenureId,ValuationId,RateId")] Parcel parcel)
        {
            if (id != parcel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcelExists(parcel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Administrationid"] = new SelectList(_context.Administration, "Id", "Id", parcel.Administrationid);
            ViewData["LandUseId"] = new SelectList(_context.LandUse, "Id", "Id", parcel.LandUseId);
            ViewData["OwnerId"] = new SelectList(_context.Owner, "Id", "Id", parcel.OwnerId);
            ViewData["OwnershipRights"] = new SelectList(_context.OwnershiRights, "Id", "Id", parcel.OwnershipRights);
            ViewData["RateId"] = new SelectList(_context.Rates, "Id", "Id", parcel.RateId);
            ViewData["RegistrationId"] = new SelectList(_context.Registration, "Id", "Id", parcel.RegistrationId);
            ViewData["Responsibilities"] = new SelectList(_context.Responsibility, "Id", "Id", parcel.Responsibilities);
            ViewData["Restrictions"] = new SelectList(_context.Restriction, "Id", "Id", parcel.Restrictions);
            ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "Id", "Id", parcel.SpatialUnitId);
            ViewData["TenureId"] = new SelectList(_context.Tenure, "Id", "Id", parcel.TenureId);
            ViewData["ValuationId"] = new SelectList(_context.Valution, "Id", "Id", parcel.ValuationId);
            return View(parcel);
        }

        // GET: Parcels1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcel
                .Include(p => p.Administration)
                .Include(p => p.LandUse)
                .Include(p => p.Owner)
                .Include(p => p.OwnershipRightsNavigation)
                .Include(p => p.Rate)
                .Include(p => p.Registration)
                .Include(p => p.ResponsibilitiesNavigation)
                .Include(p => p.RestrictionsNavigation)
                .Include(p => p.SpatialUnit)
                .Include(p => p.Tenure)
                .Include(p => p.Valuation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // POST: Parcels1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parcel = await _context.Parcel.FindAsync(id);
            _context.Parcel.Remove(parcel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcelExists(int id)
        {
            return _context.Parcel.Any(e => e.Id == id);
        }
    }
}
