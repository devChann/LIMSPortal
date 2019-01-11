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
    public class LeaseholdController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public LeaseholdController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Leasehold
        public async Task<IActionResult> Index()
        {
            var lIMSCoreDbContext = _context.Leasehold.Include(l => l.Tenure);
            return View(await lIMSCoreDbContext.ToListAsync());
        }

        // GET: Leasehold/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leasehold = await _context.Leasehold
                .Include(l => l.Tenure)
                .FirstOrDefaultAsync(m => m.LeaseholdId == id);
            if (leasehold == null)
            {
                return NotFound();
            }

            return View(leasehold);
        }

        // GET: Leasehold/Create
        public IActionResult Create()
        {
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId");
            return View();
        }

        // POST: Leasehold/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaseholdId,LeasePeriod,Lessor,TenureId")] Leasehold leasehold)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leasehold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", leasehold.TenureId);
            return View(leasehold);
        }

        // GET: Leasehold/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leasehold = await _context.Leasehold.FindAsync(id);
            if (leasehold == null)
            {
                return NotFound();
            }
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", leasehold.TenureId);
            return View(leasehold);
        }

        // POST: Leasehold/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaseholdId,LeasePeriod,Lessor,TenureId")] Leasehold leasehold)
        {
            if (id != leasehold.LeaseholdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leasehold);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaseholdExists(leasehold.LeaseholdId))
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
            ViewData["TenureId"] = new SelectList(_context.Tenure, "TenureId", "TenureId", leasehold.TenureId);
            return View(leasehold);
        }

        // GET: Leasehold/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leasehold = await _context.Leasehold
                .Include(l => l.Tenure)
                .FirstOrDefaultAsync(m => m.LeaseholdId == id);
            if (leasehold == null)
            {
                return NotFound();
            }

            return View(leasehold);
        }

        // POST: Leasehold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leasehold = await _context.Leasehold.FindAsync(id);
            _context.Leasehold.Remove(leasehold);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaseholdExists(int id)
        {
            return _context.Leasehold.Any(e => e.LeaseholdId == id);
        }
    }
}
