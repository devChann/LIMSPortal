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
    public class OwnershipRightsController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public OwnershipRightsController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: OwnershipRights
        public async Task<IActionResult> Index()
        {
            return View(await _context.OwnershiRights.ToListAsync());
        }

        // GET: OwnershipRights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownershipRights = await _context.OwnershiRights
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownershipRights == null)
            {
                return NotFound();
            }

            return View(ownershipRights);
        }

        // GET: OwnershipRights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OwnershipRights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RightType")] OwnershipRights ownershipRights)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownershipRights);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ownershipRights);
        }

        // GET: OwnershipRights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownershipRights = await _context.OwnershiRights.FindAsync(id);
            if (ownershipRights == null)
            {
                return NotFound();
            }
            return View(ownershipRights);
        }

        // POST: OwnershipRights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RightType")] OwnershipRights ownershipRights)
        {
            if (id != ownershipRights.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownershipRights);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnershipRightsExists(ownershipRights.Id))
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
            return View(ownershipRights);
        }

        // GET: OwnershipRights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownershipRights = await _context.OwnershiRights
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ownershipRights == null)
            {
                return NotFound();
            }

            return View(ownershipRights);
        }

        // POST: OwnershipRights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownershipRights = await _context.OwnershiRights.FindAsync(id);
            _context.OwnershiRights.Remove(ownershipRights);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnershipRightsExists(int id)
        {
            return _context.OwnershiRights.Any(e => e.Id == id);
        }
    }
}
