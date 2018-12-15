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
    public class LandUsesController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public LandUsesController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: LandUses
        public async Task<IActionResult> Index()
        {
            var lIMSCoreDbContext = _context.LandUse.Include(l => l.BuildingRegulations).Include(l => l.Zone);
            return View(await lIMSCoreDbContext.ToListAsync());
        }

        // GET: LandUses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landUse = await _context.LandUse
                .Include(l => l.BuildingRegulations)
                .Include(l => l.Zone)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landUse == null)
            {
                return NotFound();
            }

            return View(landUse);
        }

        // GET: LandUses/Create
        public IActionResult Create()
        {
            ViewData["BuildingRegulationsId"] = new SelectList(_context.BuildingRegulations, "Id", "Id");
            ViewData["ZoneId"] = new SelectList(_context.Zone, "Id", "Id");
            return View();
        }

        // POST: LandUses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BuildingRegulationsId,EndDate,LandUseStatus,LandUseType,RegulationAgency,StartDate,ZoneId")] LandUse landUse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(landUse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuildingRegulationsId"] = new SelectList(_context.BuildingRegulations, "Id", "Id", landUse.BuildingRegulationsId);
            ViewData["ZoneId"] = new SelectList(_context.Zone, "Id", "Id", landUse.ZoneId);
            return View(landUse);
        }

        // GET: LandUses/Edit/5
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
            ViewData["BuildingRegulationsId"] = new SelectList(_context.BuildingRegulations, "Id", "Id", landUse.BuildingRegulationsId);
            ViewData["ZoneId"] = new SelectList(_context.Zone, "Id", "Id", landUse.ZoneId);
            return View(landUse);
        }

        // POST: LandUses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BuildingRegulationsId,EndDate,LandUseStatus,LandUseType,RegulationAgency,StartDate,ZoneId")] LandUse landUse)
        {
            if (id != landUse.Id)
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
                    if (!LandUseExists(landUse.Id))
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
            ViewData["BuildingRegulationsId"] = new SelectList(_context.BuildingRegulations, "Id", "Id", landUse.BuildingRegulationsId);
            ViewData["ZoneId"] = new SelectList(_context.Zone, "Id", "Id", landUse.ZoneId);
            return View(landUse);
        }

        // GET: LandUses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landUse = await _context.LandUse
                .Include(l => l.BuildingRegulations)
                .Include(l => l.Zone)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (landUse == null)
            {
                return NotFound();
            }

            return View(landUse);
        }

        // POST: LandUses/Delete/5
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
            return _context.LandUse.Any(e => e.Id == id);
        }
    }
}
