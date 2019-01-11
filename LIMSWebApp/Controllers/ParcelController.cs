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
    public class ParcelController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public ParcelController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Parcel
        public async Task<IActionResult> Index()
        {
            var lIMSCoreDbContext = _context.Parcel.Include(p => p.Administration).Include(p => p.LandUse).Include(p => p.Owner).Include(p => p.OwnershipRight).Include(p => p.Rate).Include(p => p.Registration).Include(p => p.Responsibility).Include(p => p.Restriction).Include(p => p.SpatialUnit).Include(p => p.Tenure).Include(p => p.Valuation);
            return View(await lIMSCoreDbContext.ToListAsync());
        }

        // GET: Parcel/Details/5
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
                .Include(p => p.OwnershipRight)
                .Include(p => p.Rate)
                .Include(p => p.Registration)
                .Include(p => p.Responsibility)
                .Include(p => p.Restriction)
                .Include(p => p.SpatialUnit)
                .Include(p => p.Tenure)
                .Include(p => p.Valuation)
                .FirstOrDefaultAsync(m => m.ParcelId == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // GET: Parcel/Create
        public IActionResult Create()
        {
            ViewData["AdministrationId"] = new SelectList(_context.Administration, "AdministrationId", "AdministrationId");
            ViewData["LandUseId"] = new SelectList(_context.LandUse, "LandUseId", "LandUseId");
            ViewData["OwnerId"] = new SelectList(_context.Owner, "OwnerId", "OwnerId");
            ViewData["OwnershipRightId"] = new SelectList(_context.OwnershipRight, "OwnershipRightId", "OwnershipRightId");
            ViewData["RateId"] = new SelectList(_context.Rate, "RateId", "RateId");
            ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegistrationId", "RegistrationId");
            ViewData["ResponsibilityId"] = new SelectList(_context.Responsibility, "ResponsibilityId", "ResponsibilityId");
            ViewData["RestrictionId"] = new SelectList(_context.Restriction, "RestrictionId", "RestrictionId");
            ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "SpatialUnitId", "SpatialUnitId");
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId");
            ViewData["ValuationId"] = new SelectList(_context.Valuation, "ValuationId", "ValuationId");
            return View();
        }

        // POST: Parcel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParcelId,Area,ParcelNum,AdministrationId,LandUseId,OwnerId,OwnershipRightId,RateId,RegistrationId,ResponsibilityId,RestrictionId,SpatialUnitId,TenureId,ValuationId")] Parcel parcel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parcel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdministrationId"] = new SelectList(_context.Administration, "AdministrationId", "AdministrationId", parcel.AdministrationId);
            ViewData["LandUseId"] = new SelectList(_context.LandUse, "LandUseId", "LandUseId", parcel.LandUseId);
            ViewData["OwnerId"] = new SelectList(_context.Owner, "OwnerId", "OwnerId", parcel.OwnerId);
            ViewData["OwnershipRightId"] = new SelectList(_context.OwnershipRight, "OwnershipRightId", "OwnershipRightId", parcel.OwnershipRightId);
            ViewData["RateId"] = new SelectList(_context.Rate, "RateId", "RateId", parcel.RateId);
            ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegistrationId", "RegistrationId", parcel.RegistrationId);
            ViewData["ResponsibilityId"] = new SelectList(_context.Responsibility, "ResponsibilityId", "ResponsibilityId", parcel.ResponsibilityId);
            ViewData["RestrictionId"] = new SelectList(_context.Restriction, "RestrictionId", "RestrictionId", parcel.RestrictionId);
            ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "SpatialUnitId", "SpatialUnitId", parcel.SpatialUnitId);
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", parcel.TenureId);
            ViewData["ValuationId"] = new SelectList(_context.Valuation, "ValuationId", "ValuationId", parcel.ValuationId);
            return View(parcel);
        }

        // GET: Parcel/Edit/5
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
            ViewData["AdministrationId"] = new SelectList(_context.Administration, "AdministrationId", "AdministrationId", parcel.AdministrationId);
            ViewData["LandUseId"] = new SelectList(_context.LandUse, "LandUseId", "LandUseId", parcel.LandUseId);
            ViewData["OwnerId"] = new SelectList(_context.Owner, "OwnerId", "OwnerId", parcel.OwnerId);
            ViewData["OwnershipRightId"] = new SelectList(_context.OwnershipRight, "OwnershipRightId", "OwnershipRightId", parcel.OwnershipRightId);
            ViewData["RateId"] = new SelectList(_context.Rate, "RateId", "RateId", parcel.RateId);
            ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegistrationId", "RegistrationId", parcel.RegistrationId);
            ViewData["ResponsibilityId"] = new SelectList(_context.Responsibility, "ResponsibilityId", "ResponsibilityId", parcel.ResponsibilityId);
            ViewData["RestrictionId"] = new SelectList(_context.Restriction, "RestrictionId", "RestrictionId", parcel.RestrictionId);
            ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "SpatialUnitId", "SpatialUnitId", parcel.SpatialUnitId);
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", parcel.TenureId);
            ViewData["ValuationId"] = new SelectList(_context.Valuation, "ValuationId", "ValuationId", parcel.ValuationId);
            return View(parcel);
        }

        // POST: Parcel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParcelId,Area,ParcelNum,AdministrationId,LandUseId,OwnerId,OwnershipRightId,RateId,RegistrationId,ResponsibilityId,RestrictionId,SpatialUnitId,TenureId,ValuationId")] Parcel parcel)
        {
            if (id != parcel.ParcelId)
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
                    if (!ParcelExists(parcel.ParcelId))
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
            ViewData["AdministrationId"] = new SelectList(_context.Administration, "AdministrationId", "AdministrationId", parcel.AdministrationId);
            ViewData["LandUseId"] = new SelectList(_context.LandUse, "LandUseId", "LandUseId", parcel.LandUseId);
            ViewData["OwnerId"] = new SelectList(_context.Owner, "OwnerId", "OwnerId", parcel.OwnerId);
            ViewData["OwnershipRightId"] = new SelectList(_context.OwnershipRight, "OwnershipRightId", "OwnershipRightId", parcel.OwnershipRightId);
            ViewData["RateId"] = new SelectList(_context.Rate, "RateId", "RateId", parcel.RateId);
            ViewData["RegistrationId"] = new SelectList(_context.Registration, "RegistrationId", "RegistrationId", parcel.RegistrationId);
            ViewData["ResponsibilityId"] = new SelectList(_context.Responsibility, "ResponsibilityId", "ResponsibilityId", parcel.ResponsibilityId);
            ViewData["RestrictionId"] = new SelectList(_context.Restriction, "RestrictionId", "RestrictionId", parcel.RestrictionId);
            ViewData["SpatialUnitId"] = new SelectList(_context.SpatialUnit, "SpatialUnitId", "SpatialUnitId", parcel.SpatialUnitId);
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", parcel.TenureId);
            ViewData["ValuationId"] = new SelectList(_context.Valuation, "ValuationId", "ValuationId", parcel.ValuationId);
            return View(parcel);
        }

        // GET: Parcel/Delete/5
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
                .Include(p => p.OwnershipRight)
                .Include(p => p.Rate)
                .Include(p => p.Registration)
                .Include(p => p.Responsibility)
                .Include(p => p.Restriction)
                .Include(p => p.SpatialUnit)
                .Include(p => p.Tenure)
                .Include(p => p.Valuation)
                .FirstOrDefaultAsync(m => m.ParcelId == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // POST: Parcel/Delete/5
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
            return _context.Parcel.Any(e => e.ParcelId == id);
        }
    }
}
