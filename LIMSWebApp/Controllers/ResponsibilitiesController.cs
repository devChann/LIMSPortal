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
    public class ResponsibilitiesController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public ResponsibilitiesController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Responsibilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Responsibility.ToListAsync());
        }

        // GET: Responsibilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibility = await _context.Responsibility
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsibility == null)
            {
                return NotFound();
            }

            return View(responsibility);
        }

        // GET: Responsibilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Responsibilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PerformanceRequirement,ResponsibilityType")] Responsibility responsibility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsibility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsibility);
        }

        // GET: Responsibilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibility = await _context.Responsibility.FindAsync(id);
            if (responsibility == null)
            {
                return NotFound();
            }
            return View(responsibility);
        }

        // POST: Responsibilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PerformanceRequirement,ResponsibilityType")] Responsibility responsibility)
        {
            if (id != responsibility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsibility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsibilityExists(responsibility.Id))
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
            return View(responsibility);
        }

        // GET: Responsibilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibility = await _context.Responsibility
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsibility == null)
            {
                return NotFound();
            }

            return View(responsibility);
        }

        // POST: Responsibilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsibility = await _context.Responsibility.FindAsync(id);
            _context.Responsibility.Remove(responsibility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsibilityExists(int id)
        {
            return _context.Responsibility.Any(e => e.Id == id);
        }
    }
}
