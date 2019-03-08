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
	public class BoundaryController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public BoundaryController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Boundary
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boundary.ToListAsync());
        }

        // GET: Boundary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boundary = await _context.Boundary
                .FirstOrDefaultAsync(m => m.BoundaryId == id);
            if (boundary == null)
            {
                return NotFound();
            }

            return View(boundary);
        }

        // GET: Boundary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boundary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BoundaryId,BoundaryType")] Boundary boundary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boundary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boundary);
        }

        // GET: Boundary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boundary = await _context.Boundary.FindAsync(id);
            if (boundary == null)
            {
                return NotFound();
            }
            return View(boundary);
        }

        // POST: Boundary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BoundaryId,BoundaryType")] Boundary boundary)
        {
            if (id != boundary.BoundaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boundary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoundaryExists(boundary.BoundaryId))
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
            return View(boundary);
        }

        // GET: Boundary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boundary = await _context.Boundary
                .FirstOrDefaultAsync(m => m.BoundaryId == id);
            if (boundary == null)
            {
                return NotFound();
            }

            return View(boundary);
        }

        // POST: Boundary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boundary = await _context.Boundary.FindAsync(id);
            _context.Boundary.Remove(boundary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoundaryExists(int id)
        {
            return _context.Boundary.Any(e => e.BoundaryId == id);
        }
    }
}
