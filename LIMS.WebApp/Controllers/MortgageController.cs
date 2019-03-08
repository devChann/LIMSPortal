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
	public class MortgageController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public MortgageController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Mortgage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mortgage.ToListAsync());
        }

        // GET: Mortgage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mortgage = await _context.Mortgage
                .FirstOrDefaultAsync(m => m.MortgageId == id);
            if (mortgage == null)
            {
                return NotFound();
            }

            return View(mortgage);
        }

        // GET: Mortgage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mortgage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MortgageId,Amount,InterestRate,Lender,Ranking,RepaymentTerm")] Mortgage mortgage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mortgage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mortgage);
        }

        // GET: Mortgage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mortgage = await _context.Mortgage.FindAsync(id);
            if (mortgage == null)
            {
                return NotFound();
            }
            return View(mortgage);
        }

        // POST: Mortgage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MortgageId,Amount,InterestRate,Lender,Ranking,RepaymentTerm")] Mortgage mortgage)
        {
            if (id != mortgage.MortgageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mortgage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MortgageExists(mortgage.MortgageId))
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
            return View(mortgage);
        }

        // GET: Mortgage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mortgage = await _context.Mortgage
                .FirstOrDefaultAsync(m => m.MortgageId == id);
            if (mortgage == null)
            {
                return NotFound();
            }

            return View(mortgage);
        }

        // POST: Mortgage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mortgage = await _context.Mortgage.FindAsync(id);
            _context.Mortgage.Remove(mortgage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MortgageExists(int id)
        {
            return _context.Mortgage.Any(e => e.MortgageId == id);
        }
    }
}
