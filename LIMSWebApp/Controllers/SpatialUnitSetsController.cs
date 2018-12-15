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
    public class SpatialUnitSetsController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public SpatialUnitSetsController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: SpatialUnitSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpatialUnitSet.ToListAsync());
        }

        // GET: SpatialUnitSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialUnitSet = await _context.SpatialUnitSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spatialUnitSet == null)
            {
                return NotFound();
            }

            return View(spatialUnitSet);
        }

        // GET: SpatialUnitSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpatialUnitSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Label")] SpatialUnitSet spatialUnitSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spatialUnitSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spatialUnitSet);
        }

        // GET: SpatialUnitSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialUnitSet = await _context.SpatialUnitSet.FindAsync(id);
            if (spatialUnitSet == null)
            {
                return NotFound();
            }
            return View(spatialUnitSet);
        }

        // POST: SpatialUnitSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Label")] SpatialUnitSet spatialUnitSet)
        {
            if (id != spatialUnitSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spatialUnitSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpatialUnitSetExists(spatialUnitSet.Id))
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
            return View(spatialUnitSet);
        }

        // GET: SpatialUnitSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialUnitSet = await _context.SpatialUnitSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spatialUnitSet == null)
            {
                return NotFound();
            }

            return View(spatialUnitSet);
        }

        // POST: SpatialUnitSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spatialUnitSet = await _context.SpatialUnitSet.FindAsync(id);
            _context.SpatialUnitSet.Remove(spatialUnitSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpatialUnitSetExists(int id)
        {
            return _context.SpatialUnitSet.Any(e => e.Id == id);
        }
    }
}
