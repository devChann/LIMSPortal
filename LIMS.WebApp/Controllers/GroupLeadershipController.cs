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
	public class GroupLeadershipController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public GroupLeadershipController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: GroupLeadership
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupLeadership.ToListAsync());
        }

        // GET: GroupLeadership/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupLeadership = await _context.GroupLeadership
                .FirstOrDefaultAsync(m => m.GroupLeadershipId == id);
            if (groupLeadership == null)
            {
                return NotFound();
            }

            return View(groupLeadership);
        }

        // GET: GroupLeadership/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupLeadership/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupLeadershipId,LeadershipRole,LeadershipSince,LeadershipStatus,LeadershipUntil,PersonId")] GroupLeadership groupLeadership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupLeadership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupLeadership);
        }

        // GET: GroupLeadership/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupLeadership = await _context.GroupLeadership.FindAsync(id);
            if (groupLeadership == null)
            {
                return NotFound();
            }
            return View(groupLeadership);
        }

        // POST: GroupLeadership/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupLeadershipId,LeadershipRole,LeadershipSince,LeadershipStatus,LeadershipUntil,PersonId")] GroupLeadership groupLeadership)
        {
            if (id != groupLeadership.GroupLeadershipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupLeadership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupLeadershipExists(groupLeadership.GroupLeadershipId))
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
            return View(groupLeadership);
        }

        // GET: GroupLeadership/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupLeadership = await _context.GroupLeadership
                .FirstOrDefaultAsync(m => m.GroupLeadershipId == id);
            if (groupLeadership == null)
            {
                return NotFound();
            }

            return View(groupLeadership);
        }

        // POST: GroupLeadership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupLeadership = await _context.GroupLeadership.FindAsync(id);
            _context.GroupLeadership.Remove(groupLeadership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupLeadershipExists(int id)
        {
            return _context.GroupLeadership.Any(e => e.GroupLeadershipId == id);
        }
    }
}
