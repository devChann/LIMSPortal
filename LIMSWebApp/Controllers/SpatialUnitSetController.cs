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
    public class SpatialUnitSetController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public SpatialUnitSetController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: SpatialUnitSet
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpatialUnitSet.ToListAsync());
        }

        // GET: SpatialUnitSet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialUnitSet = await _context.SpatialUnitSet
                .FirstOrDefaultAsync(m => m.SpatialUnitSetId == id);
            if (spatialUnitSet == null)
            {
                return NotFound();
            }

            return View(spatialUnitSet);
        }

        // GET: SpatialUnitSet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpatialUnitSet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpatialUnitSetId,Label")] SpatialUnitSet spatialUnitSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spatialUnitSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spatialUnitSet);
        }

        // GET: SpatialUnitSet/Edit/5
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

        // POST: SpatialUnitSet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpatialUnitSetId,Label")] SpatialUnitSet spatialUnitSet)
        {
            if (id != spatialUnitSet.SpatialUnitSetId)
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
                    if (!SpatialUnitSetExists(spatialUnitSet.SpatialUnitSetId))
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

        // GET: SpatialUnitSet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialUnitSet = await _context.SpatialUnitSet
                .FirstOrDefaultAsync(m => m.SpatialUnitSetId == id);
            if (spatialUnitSet == null)
            {
                return NotFound();
            }

            return View(spatialUnitSet);
        }

        // POST: SpatialUnitSet/Delete/5
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
            return _context.SpatialUnitSet.Any(e => e.SpatialUnitSetId == id);
        }
    }
}
