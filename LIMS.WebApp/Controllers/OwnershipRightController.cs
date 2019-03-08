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
	public class OwnershipRightController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public OwnershipRightController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: OwnershipRight
        public async Task<IActionResult> Index()
        {
            return View(await _context.OwnershipRight.ToListAsync());
        }

        // GET: OwnershipRight/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownershipRight = await _context.OwnershipRight
                .FirstOrDefaultAsync(m => m.OwnershipRightId == id);
            if (ownershipRight == null)
            {
                return NotFound();
            }

            return View(ownershipRight);
        }

        // GET: OwnershipRight/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OwnershipRight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OwnershipRightId,RightType")] OwnershipRight ownershipRight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownershipRight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ownershipRight);
        }

        // GET: OwnershipRight/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownershipRight = await _context.OwnershipRight.FindAsync(id);
            if (ownershipRight == null)
            {
                return NotFound();
            }
            return View(ownershipRight);
        }

        // POST: OwnershipRight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OwnershipRightId,RightType")] OwnershipRight ownershipRight)
        {
            if (id != ownershipRight.OwnershipRightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownershipRight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnershipRightExists(ownershipRight.OwnershipRightId))
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
            return View(ownershipRight);
        }

        // GET: OwnershipRight/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownershipRight = await _context.OwnershipRight
                .FirstOrDefaultAsync(m => m.OwnershipRightId == id);
            if (ownershipRight == null)
            {
                return NotFound();
            }

            return View(ownershipRight);
        }

        // POST: OwnershipRight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ownershipRight = await _context.OwnershipRight.FindAsync(id);
            _context.OwnershipRight.Remove(ownershipRight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnershipRightExists(int id)
        {
            return _context.OwnershipRight.Any(e => e.OwnershipRightId == id);
        }
    }
}
