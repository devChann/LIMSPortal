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
	public class FreeholdController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public FreeholdController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Freehold
        public async Task<IActionResult> Index()
        {
            var lIMSCoreDbContext = _context.Freehold.Include(f => f.Tenure);
            return View(await lIMSCoreDbContext.ToListAsync());
        }

        // GET: Freehold/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freehold = await _context.Freehold
                .Include(f => f.Tenure)
                .FirstOrDefaultAsync(m => m.FreeholdId == id);
            if (freehold == null)
            {
                return NotFound();
            }

            return View(freehold);
        }

        // GET: Freehold/Create
        public IActionResult Create()
        {
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId");
            return View();
        }

        // POST: Freehold/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FreeholdId,TenureId")] Freehold freehold)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freehold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", freehold.TenureId);
            return View(freehold);
        }

        // GET: Freehold/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freehold = await _context.Freehold.FindAsync(id);
            if (freehold == null)
            {
                return NotFound();
            }
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", freehold.TenureId);
            return View(freehold);
        }

        // POST: Freehold/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FreeholdId,TenureId")] Freehold freehold)
        {
            if (id != freehold.FreeholdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freehold);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreeholdExists(freehold.FreeholdId))
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
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", freehold.TenureId);
            return View(freehold);
        }

        // GET: Freehold/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freehold = await _context.Freehold
                .Include(f => f.Tenure)
                .FirstOrDefaultAsync(m => m.FreeholdId == id);
            if (freehold == null)
            {
                return NotFound();
            }

            return View(freehold);
        }

        // POST: Freehold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freehold = await _context.Freehold.FindAsync(id);
            _context.Freehold.Remove(freehold);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FreeholdExists(int id)
        {
            return _context.Freehold.Any(e => e.FreeholdId == id);
        }
    }
}
