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
	public class ResponsibilityController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public ResponsibilityController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Responsibility
        public async Task<IActionResult> Index()
        {
            return View(await _context.Responsibility.ToListAsync());
        }

        // GET: Responsibility/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibility = await _context.Responsibility
                .FirstOrDefaultAsync(m => m.ResponsibilityId == id);
            if (responsibility == null)
            {
                return NotFound();
            }

            return View(responsibility);
        }

        // GET: Responsibility/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Responsibility/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponsibilityId,PerformanceRequirement,ResponsibilityType")] Responsibility responsibility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsibility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsibility);
        }

        // GET: Responsibility/Edit/5
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

        // POST: Responsibility/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponsibilityId,PerformanceRequirement,ResponsibilityType")] Responsibility responsibility)
        {
            if (id != responsibility.ResponsibilityId)
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
                    if (!ResponsibilityExists(responsibility.ResponsibilityId))
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

        // GET: Responsibility/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsibility = await _context.Responsibility
                .FirstOrDefaultAsync(m => m.ResponsibilityId == id);
            if (responsibility == null)
            {
                return NotFound();
            }

            return View(responsibility);
        }

        // POST: Responsibility/Delete/5
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
            return _context.Responsibility.Any(e => e.ResponsibilityId == id);
        }
    }
}
