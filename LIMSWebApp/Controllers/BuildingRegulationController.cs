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
	public class BuildingRegulationController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public BuildingRegulationController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: BuildingRegulation
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuildingRegulation.ToListAsync());
        }

        // GET: BuildingRegulation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingRegulation = await _context.BuildingRegulation
                .FirstOrDefaultAsync(m => m.BuildingRegulationId == id);
            if (buildingRegulation == null)
            {
                return NotFound();
            }

            return View(buildingRegulation);
        }

        // GET: BuildingRegulation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildingRegulation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuildingRegulationId,GCR,PCR,PlotFrontage")] BuildingRegulation buildingRegulation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingRegulation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingRegulation);
        }

        // GET: BuildingRegulation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingRegulation = await _context.BuildingRegulation.FindAsync(id);
            if (buildingRegulation == null)
            {
                return NotFound();
            }
            return View(buildingRegulation);
        }

        // POST: BuildingRegulation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuildingRegulationId,GCR,PCR,PlotFrontage")] BuildingRegulation buildingRegulation)
        {
            if (id != buildingRegulation.BuildingRegulationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingRegulation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingRegulationExists(buildingRegulation.BuildingRegulationId))
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
            return View(buildingRegulation);
        }

        // GET: BuildingRegulation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingRegulation = await _context.BuildingRegulation
                .FirstOrDefaultAsync(m => m.BuildingRegulationId == id);
            if (buildingRegulation == null)
            {
                return NotFound();
            }

            return View(buildingRegulation);
        }

        // POST: BuildingRegulation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingRegulation = await _context.BuildingRegulation.FindAsync(id);
            _context.BuildingRegulation.Remove(buildingRegulation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingRegulationExists(int id)
        {
            return _context.BuildingRegulation.Any(e => e.BuildingRegulationId == id);
        }
    }
}
