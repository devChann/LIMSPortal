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
	public class SpatialUnitController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public SpatialUnitController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: SpatialUnit
        public async Task<IActionResult> Index()
        {
            var lIMSCoreDbContext = _context.SpatialUnit.Include(s => s.Boundary).Include(s => s.MapIndex).Include(s => s.SpatialUnitSet).Include(s => s.Survey);
            return View(await lIMSCoreDbContext.ToListAsync());
        }

        // GET: SpatialUnit/Details/5
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
                .Include(s => s.Survey)
                .FirstOrDefaultAsync(m => m.SpatialUnitId == id);
            if (spatialUnit == null)
            {
                return NotFound();
            }

            return View(spatialUnit);
        }

        // GET: SpatialUnit/Create
        public IActionResult Create()
        {
            ViewData["BoundaryId"] = new SelectList(_context.Boundary, "BoundaryId", "BoundaryId");
            ViewData["MapIndexId"] = new SelectList(_context.MapIndex, "MapIndexId", "MapIndexId");
            ViewData["SpatialUnitSetId"] = new SelectList(_context.SpatialUnitSet, "SpatialUnitSetId", "SpatialUnitSetId");
            ViewData["SurveyId"] = new SelectList(_context.Survey, "SurveyId", "SurveyId");
            return View();
        }

        // POST: SpatialUnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpatialUnitId,Area,Label,Layer,Length,PreliminaryUnitId,ReferencePoint,SpatialUnitType,Volume,BoundaryId,MapIndexId,SpatialUnitSetId,SurveyId")] SpatialUnit spatialUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spatialUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoundaryId"] = new SelectList(_context.Boundary, "BoundaryId", "BoundaryId", spatialUnit.BoundaryId);
            ViewData["MapIndexId"] = new SelectList(_context.MapIndex, "MapIndexId", "MapIndexId", spatialUnit.MapIndexId);
            ViewData["SpatialUnitSetId"] = new SelectList(_context.SpatialUnitSet, "SpatialUnitSetId", "SpatialUnitSetId", spatialUnit.SpatialUnitSetId);
            ViewData["SurveyId"] = new SelectList(_context.Survey, "SurveyId", "SurveyId", spatialUnit.SurveyId);
            return View(spatialUnit);
        }

        // GET: SpatialUnit/Edit/5
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
            ViewData["BoundaryId"] = new SelectList(_context.Boundary, "BoundaryId", "BoundaryId", spatialUnit.BoundaryId);
            ViewData["MapIndexId"] = new SelectList(_context.MapIndex, "MapIndexId", "MapIndexId", spatialUnit.MapIndexId);
            ViewData["SpatialUnitSetId"] = new SelectList(_context.SpatialUnitSet, "SpatialUnitSetId", "SpatialUnitSetId", spatialUnit.SpatialUnitSetId);
            ViewData["SurveyId"] = new SelectList(_context.Survey, "SurveyId", "SurveyId", spatialUnit.SurveyId);
            return View(spatialUnit);
        }

        // POST: SpatialUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpatialUnitId,Area,Label,Layer,Length,PreliminaryUnitId,ReferencePoint,SpatialUnitType,Volume,BoundaryId,MapIndexId,SpatialUnitSetId,SurveyId")] SpatialUnit spatialUnit)
        {
            if (id != spatialUnit.SpatialUnitId)
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
                    if (!SpatialUnitExists(spatialUnit.SpatialUnitId))
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
            ViewData["BoundaryId"] = new SelectList(_context.Boundary, "BoundaryId", "BoundaryId", spatialUnit.BoundaryId);
            ViewData["MapIndexId"] = new SelectList(_context.MapIndex, "MapIndexId", "MapIndexId", spatialUnit.MapIndexId);
            ViewData["SpatialUnitSetId"] = new SelectList(_context.SpatialUnitSet, "SpatialUnitSetId", "SpatialUnitSetId", spatialUnit.SpatialUnitSetId);
            ViewData["SurveyId"] = new SelectList(_context.Survey, "SurveyId", "SurveyId", spatialUnit.SurveyId);
            return View(spatialUnit);
        }

        // GET: SpatialUnit/Delete/5
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
                .Include(s => s.Survey)
                .FirstOrDefaultAsync(m => m.SpatialUnitId == id);
            if (spatialUnit == null)
            {
                return NotFound();
            }

            return View(spatialUnit);
        }

        // POST: SpatialUnit/Delete/5
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
            return _context.SpatialUnit.Any(e => e.SpatialUnitId == id);
        }
    }
}
