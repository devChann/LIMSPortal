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
    public class SpatialUnitsController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public SpatialUnitsController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: SpatialUnits
        public async Task<IActionResult> Index()
        {
            var lIMSCoreDbContext = _context.SpatialUnit.Include(s => s.Boundary).Include(s => s.MapIndex).Include(s => s.SpatialUnitSet).Include(s => s.SurveyClass);
            return View(await lIMSCoreDbContext.ToListAsync());
        }

        // GET: SpatialUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialUnit = await _context.SpatialUnit
                .Include(s => s.Boundary)
                .Include(s => s.MapIndex)
                .Include(s => s.SpatialUnitSet)
                .Include(s => s.SurveyClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spatialUnit == null)
            {
                return NotFound();
            }

            return View(spatialUnit);
        }

        // GET: SpatialUnits/Create
        public IActionResult Create()
        {
            ViewData["BoundaryId"] = new SelectList(_context.Boundary, "Id", "Id");
            ViewData["MapIndexId"] = new SelectList(_context.MapIndex, "Id", "Id");
            ViewData["SpatialUnitSetId"] = new SelectList(_context.SpatialUnitSet, "Id", "Id");
            ViewData["SurveyClassId"] = new SelectList(_context.Survey, "Id", "Id");
            return View();
        }

        // POST: SpatialUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Area,BoundaryId,Label,Layer,Length,MapIndexId,PreliminaryUnitId,ReferencePoint,SpatialUnitSetId,SpatialUnitType,SurveyClassId,Volume")] SpatialUnit spatialUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spatialUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoundaryId"] = new SelectList(_context.Boundary, "Id", "Id", spatialUnit.BoundaryId);
            ViewData["MapIndexId"] = new SelectList(_context.MapIndex, "Id", "Id", spatialUnit.MapIndexId);
            ViewData["SpatialUnitSetId"] = new SelectList(_context.SpatialUnitSet, "Id", "Id", spatialUnit.SpatialUnitSetId);
            ViewData["SurveyClassId"] = new SelectList(_context.Survey, "Id", "Id", spatialUnit.SurveyClassId);
            return View(spatialUnit);
        }

        // GET: SpatialUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialUnit = await _context.SpatialUnit.FindAsync(id);
            if (spatialUnit == null)
            {
                return NotFound();
            }
            ViewData["BoundaryId"] = new SelectList(_context.Boundary, "Id", "Id", spatialUnit.BoundaryId);
            ViewData["MapIndexId"] = new SelectList(_context.MapIndex, "Id", "Id", spatialUnit.MapIndexId);
            ViewData["SpatialUnitSetId"] = new SelectList(_context.SpatialUnitSet, "Id", "Id", spatialUnit.SpatialUnitSetId);
            ViewData["SurveyClassId"] = new SelectList(_context.Survey, "Id", "Id", spatialUnit.SurveyClassId);
            return View(spatialUnit);
        }

        // POST: SpatialUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Area,BoundaryId,Label,Layer,Length,MapIndexId,PreliminaryUnitId,ReferencePoint,SpatialUnitSetId,SpatialUnitType,SurveyClassId,Volume")] SpatialUnit spatialUnit)
        {
            if (id != spatialUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spatialUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpatialUnitExists(spatialUnit.Id))
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
            ViewData["BoundaryId"] = new SelectList(_context.Boundary, "Id", "Id", spatialUnit.BoundaryId);
            ViewData["MapIndexId"] = new SelectList(_context.MapIndex, "Id", "Id", spatialUnit.MapIndexId);
            ViewData["SpatialUnitSetId"] = new SelectList(_context.SpatialUnitSet, "Id", "Id", spatialUnit.SpatialUnitSetId);
            ViewData["SurveyClassId"] = new SelectList(_context.Survey, "Id", "Id", spatialUnit.SurveyClassId);
            return View(spatialUnit);
        }

        // GET: SpatialUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialUnit = await _context.SpatialUnit
                .Include(s => s.Boundary)
                .Include(s => s.MapIndex)
                .Include(s => s.SpatialUnitSet)
                .Include(s => s.SurveyClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spatialUnit == null)
            {
                return NotFound();
            }

            return View(spatialUnit);
        }

        // POST: SpatialUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spatialUnit = await _context.SpatialUnit.FindAsync(id);
            _context.SpatialUnit.Remove(spatialUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpatialUnitExists(int id)
        {
            return _context.SpatialUnit.Any(e => e.Id == id);
        }
    }
}
