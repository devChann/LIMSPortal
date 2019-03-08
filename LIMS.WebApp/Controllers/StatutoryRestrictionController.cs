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
	public class StatutoryRestrictionController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public StatutoryRestrictionController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: StatutoryRestriction
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatutoryRestriction.ToListAsync());
        }

        // GET: StatutoryRestriction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statutoryRestriction = await _context.StatutoryRestriction
                .FirstOrDefaultAsync(m => m.StatutoryRestrictionId == id);
            if (statutoryRestriction == null)
            {
                return NotFound();
            }

            return View(statutoryRestriction);
        }

        // GET: StatutoryRestriction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatutoryRestriction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatutoryRestrictionId,NatureOfRestriction,RestrictingAuthority")] StatutoryRestriction statutoryRestriction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statutoryRestriction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statutoryRestriction);
        }

        // GET: StatutoryRestriction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statutoryRestriction = await _context.StatutoryRestriction.FindAsync(id);
            if (statutoryRestriction == null)
            {
                return NotFound();
            }
            return View(statutoryRestriction);
        }

        // POST: StatutoryRestriction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatutoryRestrictionId,NatureOfRestriction,RestrictingAuthority")] StatutoryRestriction statutoryRestriction)
        {
            if (id != statutoryRestriction.StatutoryRestrictionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statutoryRestriction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatutoryRestrictionExists(statutoryRestriction.StatutoryRestrictionId))
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
            return View(statutoryRestriction);
        }

        // GET: StatutoryRestriction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statutoryRestriction = await _context.StatutoryRestriction
                .FirstOrDefaultAsync(m => m.StatutoryRestrictionId == id);
            if (statutoryRestriction == null)
            {
                return NotFound();
            }

            return View(statutoryRestriction);
        }

        // POST: StatutoryRestriction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statutoryRestriction = await _context.StatutoryRestriction.FindAsync(id);
            _context.StatutoryRestriction.Remove(statutoryRestriction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatutoryRestrictionExists(int id)
        {
            return _context.StatutoryRestriction.Any(e => e.StatutoryRestrictionId == id);
        }
    }
}
