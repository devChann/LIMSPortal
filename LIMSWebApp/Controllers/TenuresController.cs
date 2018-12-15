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
    public class TenuresController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public TenuresController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Tenures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tenure.ToListAsync());
        }

        // GET: Tenures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenure = await _context.Tenure
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenure == null)
            {
                return NotFound();
            }

            return View(tenure);
        }

        // GET: Tenures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tenures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenureType")] Tenure tenure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenure);
        }

        // GET: Tenures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenure = await _context.Tenure.FindAsync(id);
            if (tenure == null)
            {
                return NotFound();
            }
            return View(tenure);
        }

        // POST: Tenures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenureType")] Tenure tenure)
        {
            if (id != tenure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenureExists(tenure.Id))
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
            return View(tenure);
        }

        // GET: Tenures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenure = await _context.Tenure
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tenure == null)
            {
                return NotFound();
            }

            return View(tenure);
        }

        // POST: Tenures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenure = await _context.Tenure.FindAsync(id);
            _context.Tenure.Remove(tenure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenureExists(int id)
        {
            return _context.Tenure.Any(e => e.Id == id);
        }
    }
}
