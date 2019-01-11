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
    public class MapIndexController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public MapIndexController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: MapIndex
        public async Task<IActionResult> Index()
        {
            return View(await _context.MapIndex.ToListAsync());
        }

        // GET: MapIndex/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapIndex = await _context.MapIndex
                .FirstOrDefaultAsync(m => m.MapIndexId == id);
            if (mapIndex == null)
            {
                return NotFound();
            }

            return View(mapIndex);
        }

        // GET: MapIndex/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MapIndex/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MapIndexId,MapSheetNum")] MapIndex mapIndex)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapIndex);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mapIndex);
        }

        // GET: MapIndex/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapIndex = await _context.MapIndex.FindAsync(id);
            if (mapIndex == null)
            {
                return NotFound();
            }
            return View(mapIndex);
        }

        // POST: MapIndex/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MapIndexId,MapSheetNum")] MapIndex mapIndex)
        {
            if (id != mapIndex.MapIndexId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mapIndex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapIndexExists(mapIndex.MapIndexId))
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
            return View(mapIndex);
        }

        // GET: MapIndex/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapIndex = await _context.MapIndex
                .FirstOrDefaultAsync(m => m.MapIndexId == id);
            if (mapIndex == null)
            {
                return NotFound();
            }

            return View(mapIndex);
        }

        // POST: MapIndex/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mapIndex = await _context.MapIndex.FindAsync(id);
            _context.MapIndex.Remove(mapIndex);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapIndexExists(int id)
        {
            return _context.MapIndex.Any(e => e.MapIndexId == id);
        }
    }
}
