using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIMSCore.Entities;
using LIMSInfrastructure.Data;
using Microsoft.AspNetCore.Authorization;

namespace LIMSWebApp.Controllers
{
	[Authorize]
	public class LandUseController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public LandUseController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: LandUse
        public async Task<IActionResult> Index()
        {
            var lIMSCoreDbContext = _context.LandUse.Include(l => l.BuildingRegulation).Include(l => l.Zone);
            return View(await lIMSCoreDbContext.ToListAsync());
        }

        // GET: LandUse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landUse = await _context.LandUse
                .Include(l => l.BuildingRegulation)
                .Include(l => l.Zone)
                .FirstOrDefaultAsync(m => m.LandUseId == id);
            if (landUse == null)
            {
                return NotFound();
            }

            return View(landUse);
        }

        // GET: LandUse/Create
        public IActionResult Create()
        {
            ViewData["BuildingRegulationId"] = new SelectList(_context.BuildingRegulation, "BuildingRegulationId", "BuildingRegulationId");
            ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneId");
            return View();
        }

        // POST: LandUse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LandUseId,StartDate,EndDate,LandUseStatus,LandUseType,RegulationAgency,BuildingRegulationId,ZoneId")] LandUse landUse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landUse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingRegulationId"] = new SelectList(_context.BuildingRegulation, "BuildingRegulationId", "BuildingRegulationId", landUse.BuildingRegulationId);
            ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneId", landUse.ZoneId);
            return View(landUse);
        }

        // GET: LandUse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landUse = await _context.LandUse.FindAsync(id);
            if (landUse == null)
            {
                return NotFound();
            }
            ViewData["BuildingRegulationId"] = new SelectList(_context.BuildingRegulation, "BuildingRegulationId", "BuildingRegulationId", landUse.BuildingRegulationId);
            ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneId", landUse.ZoneId);
            return View(landUse);
        }

        // POST: LandUse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LandUseId,StartDate,EndDate,LandUseStatus,LandUseType,RegulationAgency,BuildingRegulationId,ZoneId")] LandUse landUse)
        {
            if (id != landUse.LandUseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(landUse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandUseExists(landUse.LandUseId))
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
            ViewData["BuildingRegulationId"] = new SelectList(_context.BuildingRegulation, "BuildingRegulationId", "BuildingRegulationId", landUse.BuildingRegulationId);
            ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneId", landUse.ZoneId);
            return View(landUse);
        }

        // GET: LandUse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landUse = await _context.LandUse
                .Include(l => l.BuildingRegulation)
                .Include(l => l.Zone)
                .FirstOrDefaultAsync(m => m.LandUseId == id);
            if (landUse == null)
            {
                return NotFound();
            }

            return View(landUse);
        }

        // POST: LandUse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landUse = await _context.LandUse.FindAsync(id);
            _context.LandUse.Remove(landUse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandUseExists(int id)
        {
            return _context.LandUse.Any(e => e.LandUseId == id);
        }
    }
}
