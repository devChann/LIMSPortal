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
    public class MortgagesController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public MortgagesController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Mortgages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mortgage.ToListAsync());
        }

        // GET: Mortgages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mortgage = await _context.Mortgage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mortgage == null)
            {
                return NotFound();
            }

            return View(mortgage);
        }

        // GET: Mortgages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mortgages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,BuildingId,InterestRate,Lender,Ranking,RepaymentTerm")] Mortgage mortgage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mortgage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mortgage);
        }

        // GET: Mortgages/Edit/5
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

        // POST: Mortgages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,BuildingId,InterestRate,Lender,Ranking,RepaymentTerm")] Mortgage mortgage)
        {
            if (id != mortgage.Id)
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
                    if (!MortgageExists(mortgage.Id))
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

        // GET: Mortgages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mortgage = await _context.Mortgage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mortgage == null)
            {
                return NotFound();
            }

            return View(mortgage);
        }

        // POST: Mortgages/Delete/5
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
            return _context.Mortgage.Any(e => e.Id == id);
        }
    }
}
