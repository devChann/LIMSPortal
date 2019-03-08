using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIMS.Core.Entities;
using LIMS.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;

namespace LIMS.WebApp.Controllers
{
	[Authorize]
	public class RestrictionController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public RestrictionController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Restriction
        public async Task<IActionResult> Index()
        {
            var LIMSCoreDbContext = _context.Restriction.Include(r => r.Charge).Include(r => r.Mortgage).Include(r => r.Reserve).Include(r => r.StatutoryRestriction);
            return View(await LIMSCoreDbContext.ToListAsync());
        }

        // GET: Restriction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restriction = await _context.Restriction
                .Include(r => r.Charge)
                .Include(r => r.Mortgage)
                .Include(r => r.Reserve)
                .Include(r => r.StatutoryRestriction)
                .FirstOrDefaultAsync(m => m.RestrictionId == id);
            if (restriction == null)
            {
                return NotFound();
            }

            return View(restriction);
        }

        // GET: Restriction/Create
        public IActionResult Create()
        {
            ViewData["ChargeId"] = new SelectList(_context.Charge, "ChargeId", "ChargeId");
            ViewData["MortgageId"] = new SelectList(_context.Mortgage, "MortgageId", "MortgageId");
            ViewData["ReserveId"] = new SelectList(_context.Reserve, "ReserveId", "ReserveId");
            ViewData["StatutoryRestrictionId"] = new SelectList(_context.StatutoryRestriction, "StatutoryRestrictionId", "StatutoryRestrictionId");
            return View();
        }

        // POST: Restriction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestrictionId,RestrictionType,ChargeId,MortgageId,ReserveId,StatutoryRestrictionId")] Restriction restriction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restriction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChargeId"] = new SelectList(_context.Charge, "ChargeId", "ChargeId", restriction.ChargeId);
            ViewData["MortgageId"] = new SelectList(_context.Mortgage, "MortgageId", "MortgageId", restriction.MortgageId);
            ViewData["ReserveId"] = new SelectList(_context.Reserve, "ReserveId", "ReserveId", restriction.ReserveId);
            ViewData["StatutoryRestrictionId"] = new SelectList(_context.StatutoryRestriction, "StatutoryRestrictionId", "StatutoryRestrictionId", restriction.StatutoryRestrictionId);
            return View(restriction);
        }

        // GET: Restriction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restriction = await _context.Restriction.FindAsync(id);
            if (restriction == null)
            {
                return NotFound();
            }
            ViewData["ChargeId"] = new SelectList(_context.Charge, "ChargeId", "ChargeId", restriction.ChargeId);
            ViewData["MortgageId"] = new SelectList(_context.Mortgage, "MortgageId", "MortgageId", restriction.MortgageId);
            ViewData["ReserveId"] = new SelectList(_context.Reserve, "ReserveId", "ReserveId", restriction.ReserveId);
            ViewData["StatutoryRestrictionId"] = new SelectList(_context.StatutoryRestriction, "StatutoryRestrictionId", "StatutoryRestrictionId", restriction.StatutoryRestrictionId);
            return View(restriction);
        }

        // POST: Restriction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RestrictionId,RestrictionType,ChargeId,MortgageId,ReserveId,StatutoryRestrictionId")] Restriction restriction)
        {
            if (id != restriction.RestrictionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restriction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestrictionExists(restriction.RestrictionId))
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
            ViewData["ChargeId"] = new SelectList(_context.Charge, "ChargeId", "ChargeId", restriction.ChargeId);
            ViewData["MortgageId"] = new SelectList(_context.Mortgage, "MortgageId", "MortgageId", restriction.MortgageId);
            ViewData["ReserveId"] = new SelectList(_context.Reserve, "ReserveId", "ReserveId", restriction.ReserveId);
            ViewData["StatutoryRestrictionId"] = new SelectList(_context.StatutoryRestriction, "StatutoryRestrictionId", "StatutoryRestrictionId", restriction.StatutoryRestrictionId);
            return View(restriction);
        }

        // GET: Restriction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restriction = await _context.Restriction
                .Include(r => r.Charge)
                .Include(r => r.Mortgage)
                .Include(r => r.Reserve)
                .Include(r => r.StatutoryRestriction)
                .FirstOrDefaultAsync(m => m.RestrictionId == id);
            if (restriction == null)
            {
                return NotFound();
            }

            return View(restriction);
        }

        // POST: Restriction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restriction = await _context.Restriction.FindAsync(id);
            _context.Restriction.Remove(restriction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestrictionExists(int id)
        {
            return _context.Restriction.Any(e => e.RestrictionId == id);
        }
    }
}
