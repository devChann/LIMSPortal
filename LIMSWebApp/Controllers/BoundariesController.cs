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
    public class BoundariesController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public BoundariesController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Boundaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boundary.ToListAsync());
        }

        // GET: Boundaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boundary = await _context.Boundary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boundary == null)
            {
                return NotFound();
            }

            return View(boundary);
        }

        // GET: Boundaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boundaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BoundaryType")] Boundary boundary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boundary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boundary);
        }

        // GET: Boundaries/Edit/5
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

        // POST: Boundaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BoundaryType")] Boundary boundary)
        {
            if (id != boundary.Id)
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
                    if (!BoundaryExists(boundary.Id))
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

        // GET: Boundaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boundary = await _context.Boundary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boundary == null)
            {
                return NotFound();
            }

            return View(boundary);
        }

        // POST: Boundaries/Delete/5
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
            return _context.Boundary.Any(e => e.Id == id);
        }
    }
}
