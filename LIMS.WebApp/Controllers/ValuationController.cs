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
	public class ValuationController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public ValuationController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Valuation
        public async Task<IActionResult> Index()
        {
            return View(await _context.Valuation.ToListAsync());
        }

        // GET: Valuation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valuation = await _context.Valuation
                .FirstOrDefaultAsync(m => m.ValuationId == id);
            if (valuation == null)
            {
                return NotFound();
            }

            return View(valuation);
        }

        // GET: Valuation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Valuation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ValuationId,Remarks,SerialNo,ValuationBookNo,ValuationDate,Value,Valuer")] Valuation valuation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valuation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(valuation);
        }

        // GET: Valuation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valuation = await _context.Valuation.FindAsync(id);
            if (valuation == null)
            {
                return NotFound();
            }
            return View(valuation);
        }

        // POST: Valuation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ValuationId,Remarks,SerialNo,ValuationBookNo,ValuationDate,Value,Valuer")] Valuation valuation)
        {
            if (id != valuation.ValuationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valuation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValuationExists(valuation.ValuationId))
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
            return View(valuation);
        }

        // GET: Valuation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valuation = await _context.Valuation
                .FirstOrDefaultAsync(m => m.ValuationId == id);
            if (valuation == null)
            {
                return NotFound();
            }

            return View(valuation);
        }

        // POST: Valuation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var valuation = await _context.Valuation.FindAsync(id);
            _context.Valuation.Remove(valuation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValuationExists(int id)
        {
            return _context.Valuation.Any(e => e.ValuationId == id);
        }
    }
}
