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
    public class RestrictionsController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public RestrictionsController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Restrictions
        public async Task<IActionResult> Index()
        {
            var lIMSCoreDbContext = _context.Restriction.Include(r => r.Chrage).Include(r => r.Morgage).Include(r => r.Reserve).Include(r => r.Statutory);
            return View(await lIMSCoreDbContext.ToListAsync());
        }

        // GET: Restrictions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restriction = await _context.Restriction
                .Include(r => r.Chrage)
                .Include(r => r.Morgage)
                .Include(r => r.Reserve)
                .Include(r => r.Statutory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restriction == null)
            {
                return NotFound();
            }

            return View(restriction);
        }

        // GET: Restrictions/Create
        public IActionResult Create()
        {
            ViewData["ChrageId"] = new SelectList(_context.Charge, "Id", "Id");
            ViewData["Morgageid"] = new SelectList(_context.Mortgage, "Id", "Id");
            ViewData["ReserveId"] = new SelectList(_context.Reserve, "Id", "Id");
            ViewData["Statutoryid"] = new SelectList(_context.StaturtoryRestriction, "Id", "Id");
            return View();
        }

        // POST: Restrictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChrageId,LandUseId,Morgageid,ReserveId,RestrictionType,Statutoryid")] Restriction restriction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restriction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChrageId"] = new SelectList(_context.Charge, "Id", "Id", restriction.ChrageId);
            ViewData["Morgageid"] = new SelectList(_context.Mortgage, "Id", "Id", restriction.Morgageid);
            ViewData["ReserveId"] = new SelectList(_context.Reserve, "Id", "Id", restriction.ReserveId);
            ViewData["Statutoryid"] = new SelectList(_context.StaturtoryRestriction, "Id", "Id", restriction.Statutoryid);
            return View(restriction);
        }

        // GET: Restrictions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restriction = await _context.Restriction.FindAsync(id);
            if (restriction == null)
            {
                return NotFound();
            }
            ViewData["ChrageId"] = new SelectList(_context.Charge, "Id", "Id", restriction.ChrageId);
            ViewData["Morgageid"] = new SelectList(_context.Mortgage, "Id", "Id", restriction.Morgageid);
            ViewData["ReserveId"] = new SelectList(_context.Reserve, "Id", "Id", restriction.ReserveId);
            ViewData["Statutoryid"] = new SelectList(_context.StaturtoryRestriction, "Id", "Id", restriction.Statutoryid);
            return View(restriction);
        }

        // POST: Restrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChrageId,LandUseId,Morgageid,ReserveId,RestrictionType,Statutoryid")] Restriction restriction)
        {
            if (id != restriction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restriction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestrictionExists(restriction.Id))
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
            ViewData["ChrageId"] = new SelectList(_context.Charge, "Id", "Id", restriction.ChrageId);
            ViewData["Morgageid"] = new SelectList(_context.Mortgage, "Id", "Id", restriction.Morgageid);
            ViewData["ReserveId"] = new SelectList(_context.Reserve, "Id", "Id", restriction.ReserveId);
            ViewData["Statutoryid"] = new SelectList(_context.StaturtoryRestriction, "Id", "Id", restriction.Statutoryid);
            return View(restriction);
        }

        // GET: Restrictions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restriction = await _context.Restriction
                .Include(r => r.Chrage)
                .Include(r => r.Morgage)
                .Include(r => r.Reserve)
                .Include(r => r.Statutory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restriction == null)
            {
                return NotFound();
            }

            return View(restriction);
        }

        // POST: Restrictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restriction = await _context.Restriction.FindAsync(id);
            _context.Restriction.Remove(restriction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestrictionExists(int id)
        {
            return _context.Restriction.Any(e => e.Id == id);
        }
    }
}
