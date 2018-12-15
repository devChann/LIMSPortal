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
    public class BuildingRegulationsController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public BuildingRegulationsController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: BuildingRegulations
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuildingRegulations.ToListAsync());
        }

        // GET: BuildingRegulations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingRegulations = await _context.BuildingRegulations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingRegulations == null)
            {
                return NotFound();
            }

            return View(buildingRegulations);
        }

        // GET: BuildingRegulations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuildingRegulations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gcr,Pcr,PlotFrontage")] BuildingRegulations buildingRegulations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingRegulations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingRegulations);
        }

        // GET: BuildingRegulations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingRegulations = await _context.BuildingRegulations.FindAsync(id);
            if (buildingRegulations == null)
            {
                return NotFound();
            }
            return View(buildingRegulations);
        }

        // POST: BuildingRegulations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gcr,Pcr,PlotFrontage")] BuildingRegulations buildingRegulations)
        {
            if (id != buildingRegulations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingRegulations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingRegulationsExists(buildingRegulations.Id))
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
            return View(buildingRegulations);
        }

        // GET: BuildingRegulations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingRegulations = await _context.BuildingRegulations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingRegulations == null)
            {
                return NotFound();
            }

            return View(buildingRegulations);
        }

        // POST: BuildingRegulations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingRegulations = await _context.BuildingRegulations.FindAsync(id);
            _context.BuildingRegulations.Remove(buildingRegulations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingRegulationsExists(int id)
        {
            return _context.BuildingRegulations.Any(e => e.Id == id);
        }
    }
}
