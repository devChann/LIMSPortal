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
    public class StaturtoryRestrictionsController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public StaturtoryRestrictionsController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: StaturtoryRestrictions
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaturtoryRestriction.ToListAsync());
        }

        // GET: StaturtoryRestrictions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staturtoryRestriction = await _context.StaturtoryRestriction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staturtoryRestriction == null)
            {
                return NotFound();
            }

            return View(staturtoryRestriction);
        }

        // GET: StaturtoryRestrictions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaturtoryRestrictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NatureOfRestriction,RestrictingAuthority")] StaturtoryRestriction staturtoryRestriction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staturtoryRestriction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staturtoryRestriction);
        }

        // GET: StaturtoryRestrictions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staturtoryRestriction = await _context.StaturtoryRestriction.FindAsync(id);
            if (staturtoryRestriction == null)
            {
                return NotFound();
            }
            return View(staturtoryRestriction);
        }

        // POST: StaturtoryRestrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NatureOfRestriction,RestrictingAuthority")] StaturtoryRestriction staturtoryRestriction)
        {
            if (id != staturtoryRestriction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staturtoryRestriction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaturtoryRestrictionExists(staturtoryRestriction.Id))
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
            return View(staturtoryRestriction);
        }

        // GET: StaturtoryRestrictions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staturtoryRestriction = await _context.StaturtoryRestriction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staturtoryRestriction == null)
            {
                return NotFound();
            }

            return View(staturtoryRestriction);
        }

        // POST: StaturtoryRestrictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staturtoryRestriction = await _context.StaturtoryRestriction.FindAsync(id);
            _context.StaturtoryRestriction.Remove(staturtoryRestriction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaturtoryRestrictionExists(int id)
        {
            return _context.StaturtoryRestriction.Any(e => e.Id == id);
        }
    }
}
