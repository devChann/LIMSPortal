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
    public class ChargesController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public ChargesController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Charges
        public async Task<IActionResult> Index()
        {
            return View(await _context.Charge.ToListAsync());
        }

        // GET: Charges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charge = await _context.Charge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (charge == null)
            {
                return NotFound();
            }

            return View(charge);
        }

        // GET: Charges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Charges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,InterestRate,Lender,Ranking,RepaymentTerm")] Charge charge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(charge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(charge);
        }

        // GET: Charges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charge = await _context.Charge.FindAsync(id);
            if (charge == null)
            {
                return NotFound();
            }
            return View(charge);
        }

        // POST: Charges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,InterestRate,Lender,Ranking,RepaymentTerm")] Charge charge)
        {
            if (id != charge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChargeExists(charge.Id))
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
            return View(charge);
        }

        // GET: Charges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charge = await _context.Charge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (charge == null)
            {
                return NotFound();
            }

            return View(charge);
        }

        // POST: Charges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var charge = await _context.Charge.FindAsync(id);
            _context.Charge.Remove(charge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChargeExists(int id)
        {
            return _context.Charge.Any(e => e.Id == id);
        }
    }
}
