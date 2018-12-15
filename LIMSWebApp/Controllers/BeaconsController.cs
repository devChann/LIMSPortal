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
    public class BeaconsController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public BeaconsController(LIMSCoreDbContext context)
        {
            _context = context;
        }

        // GET: Beacons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beacon.ToListAsync());
        }

        // GET: Beacons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beacon = await _context.Beacon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beacon == null)
            {
                return NotFound();
            }

            return View(beacon);
        }

        // GET: Beacons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beacons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BeaconNum,BeaconType,DateSet,Hcoordinate,HorizontalDatum,VerticalDatum,Xcoordinate,Ycoordinate")] Beacon beacon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beacon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beacon);
        }

        // GET: Beacons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beacon = await _context.Beacon.FindAsync(id);
            if (beacon == null)
            {
                return NotFound();
            }
            return View(beacon);
        }

        // POST: Beacons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BeaconNum,BeaconType,DateSet,Hcoordinate,HorizontalDatum,VerticalDatum,Xcoordinate,Ycoordinate")] Beacon beacon)
        {
            if (id != beacon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beacon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeaconExists(beacon.Id))
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
            return View(beacon);
        }

        // GET: Beacons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beacon = await _context.Beacon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beacon == null)
            {
                return NotFound();
            }

            return View(beacon);
        }

        // POST: Beacons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beacon = await _context.Beacon.FindAsync(id);
            _context.Beacon.Remove(beacon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeaconExists(int id)
        {
            return _context.Beacon.Any(e => e.Id == id);
        }
    }
}
