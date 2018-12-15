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
    public class ValutionsController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public ValutionsController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Valutions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Valution.ToListAsync());
        }

        // GET: Valutions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valution = await _context.Valution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (valution == null)
            {
                return NotFound();
            }

            return View(valution);
        }

        // GET: Valutions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Valutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Remarks,SerialNo,ValuationBookNo,ValuationDate,Value,Valuer")] Valution valution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(valution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(valution);
        }

        // GET: Valutions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valution = await _context.Valution.FindAsync(id);
            if (valution == null)
            {
                return NotFound();
            }
            return View(valution);
        }

        // POST: Valutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Remarks,SerialNo,ValuationBookNo,ValuationDate,Value,Valuer")] Valution valution)
        {
            if (id != valution.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValutionExists(valution.Id))
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
            return View(valution);
        }

        // GET: Valutions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valution = await _context.Valution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (valution == null)
            {
                return NotFound();
            }

            return View(valution);
        }

        // POST: Valutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var valution = await _context.Valution.FindAsync(id);
            _context.Valution.Remove(valution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValutionExists(int id)
        {
            return _context.Valution.Any(e => e.Id == id);
        }
    }
}
