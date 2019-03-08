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
	public class InsitutionLeadershipController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public InsitutionLeadershipController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: InsitutionLeadership
        public async Task<IActionResult> Index()
        {
            return View(await _context.InsitutionLeadership.ToListAsync());
        }

        // GET: InsitutionLeadership/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insitutionLeadership = await _context.InsitutionLeadership
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insitutionLeadership == null)
            {
                return NotFound();
            }

            return View(insitutionLeadership);
        }

        // GET: InsitutionLeadership/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsitutionLeadership/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MemberSince,MemberUntil,MembershipRole,MembershipStatus")] InsitutionLeadership insitutionLeadership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insitutionLeadership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insitutionLeadership);
        }

        // GET: InsitutionLeadership/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insitutionLeadership = await _context.InsitutionLeadership.FindAsync(id);
            if (insitutionLeadership == null)
            {
                return NotFound();
            }
            return View(insitutionLeadership);
        }

        // POST: InsitutionLeadership/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MemberSince,MemberUntil,MembershipRole,MembershipStatus")] InsitutionLeadership insitutionLeadership)
        {
            if (id != insitutionLeadership.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insitutionLeadership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsitutionLeadershipExists(insitutionLeadership.Id))
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
            return View(insitutionLeadership);
        }

        // GET: InsitutionLeadership/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insitutionLeadership = await _context.InsitutionLeadership
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insitutionLeadership == null)
            {
                return NotFound();
            }

            return View(insitutionLeadership);
        }

        // POST: InsitutionLeadership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insitutionLeadership = await _context.InsitutionLeadership.FindAsync(id);
            _context.InsitutionLeadership.Remove(insitutionLeadership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsitutionLeadershipExists(int id)
        {
            return _context.InsitutionLeadership.Any(e => e.Id == id);
        }
    }
}
