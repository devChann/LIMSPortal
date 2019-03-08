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
	public class OperationController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public OperationController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Operation
        public async Task<IActionResult> Index()
        {
            var LIMSCoreDbContext = _context.Operation.Include(o => o.Parcel);
            return View(await LIMSCoreDbContext.ToListAsync());
        }

        // GET: Operation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operation = await _context.Operation
                .Include(o => o.Parcel)
                .FirstOrDefaultAsync(m => m.OperationId == id);
            if (operation == null)
            {
                return NotFound();
            }

            return View(operation);
        }

        // GET: Operation/Create
        public IActionResult Create()
        {
            ViewData["ParcelId"] = new SelectList(_context.Parcel, "ParcelId", "ParcelNum");
            return View();
        }

        // POST: Operation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OperationId,OperationName,ParcelId")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParcelId"] = new SelectList(_context.Parcel, "ParcelId", "ParcelNum", operation.ParcelId);
            return View(operation);
        }

        // GET: Operation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operation = await _context.Operation.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }
            ViewData["ParcelId"] = new SelectList(_context.Parcel, "ParcelId", "ParcelNum", operation.ParcelId);
            return View(operation);
        }

        // POST: Operation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OperationId,OperationName,ParcelId")] Operation operation)
        {
            if (id != operation.OperationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperationExists(operation.OperationId))
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
            ViewData["ParcelId"] = new SelectList(_context.Parcel, "ParcelId", "ParcelNum", operation.ParcelId);
            return View(operation);
        }

        // GET: Operation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operation = await _context.Operation
                .Include(o => o.Parcel)
                .FirstOrDefaultAsync(m => m.OperationId == id);
            if (operation == null)
            {
                return NotFound();
            }

            return View(operation);
        }

        // POST: Operation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operation = await _context.Operation.FindAsync(id);
            _context.Operation.Remove(operation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperationExists(int id)
        {
            return _context.Operation.Any(e => e.OperationId == id);
        }
    }
}
