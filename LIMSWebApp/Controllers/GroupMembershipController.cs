using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIMSCore.Entities;
using LIMSInfrastructure.Data;
using Microsoft.AspNetCore.Authorization;

namespace LIMSWebApp.Controllers
{
	[Authorize]
	public class GroupMembershipController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public GroupMembershipController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: GroupMembership
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupMembership.ToListAsync());
        }

        // GET: GroupMembership/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMembership = await _context.GroupMembership
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupMembership == null)
            {
                return NotFound();
            }

            return View(groupMembership);
        }

        // GET: GroupMembership/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupMembership/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MembershipShare,MembershipSince,MembershipStatus,MembershipUntil")] GroupMembership groupMembership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupMembership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupMembership);
        }

        // GET: GroupMembership/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMembership = await _context.GroupMembership.FindAsync(id);
            if (groupMembership == null)
            {
                return NotFound();
            }
            return View(groupMembership);
        }

        // POST: GroupMembership/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MembershipShare,MembershipSince,MembershipStatus,MembershipUntil")] GroupMembership groupMembership)
        {
            if (id != groupMembership.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupMembership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupMembershipExists(groupMembership.Id))
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
            return View(groupMembership);
        }

        // GET: GroupMembership/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMembership = await _context.GroupMembership
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupMembership == null)
            {
                return NotFound();
            }

            return View(groupMembership);
        }

        // POST: GroupMembership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupMembership = await _context.GroupMembership.FindAsync(id);
            _context.GroupMembership.Remove(groupMembership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupMembershipExists(int id)
        {
            return _context.GroupMembership.Any(e => e.Id == id);
        }
    }
}
