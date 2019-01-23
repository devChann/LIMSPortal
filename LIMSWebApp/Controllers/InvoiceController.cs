using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIMSCore.Billing;
using LIMSInfrastructure.Data;

namespace LIMSWebApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public InvoiceController(LIMSCoreDbContext context)
        {
            _context = context;
        }

		//// GET: Invoice
		//public async Task<IActionResult> Index()
		//{
		//	var lIMSCoreDbContext = _context.Invoice.Include(i => i.Parcel);
		//	return View(await lIMSCoreDbContext.ToListAsync());
		//}

		// GET: Invoice
		public async Task<IActionResult> Index(string parcelnum)
		{
			var Invoices = _context.Invoice.Include(i => i.Parcel).Where(a => a.Parcel.ParcelNum == parcelnum);

			return View(await Invoices.ToListAsync());
		}

		// GET: Invoice/Details/5
		public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Parcel)
                .FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoice/Create
        public IActionResult Create()
        {
            ViewData["ParcelId"] = new SelectList(_context.Parcel, "ParcelId", "ParcelNum");
            return View();
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceId,InvoiceNumber,InvoiceAmount,ParcelId")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoice.InvoiceId = Guid.NewGuid();
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParcelId"] = new SelectList(_context.Parcel, "ParcelId", "ParcelNum", invoice.ParcelId);
            return View(invoice);
        }

        // GET: Invoice/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["ParcelId"] = new SelectList(_context.Parcel, "ParcelId", "ParcelNum", invoice.ParcelId);
            return View(invoice);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("InvoiceId,InvoiceNumber,InvoiceAmount,DateCreated,DateDue,ParcelId")] Invoice invoice)
        {
            if (id != invoice.InvoiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.InvoiceId))
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
            ViewData["ParcelId"] = new SelectList(_context.Parcel, "ParcelId", "ParcelNum", invoice.ParcelId);
            return View(invoice);
        }

        // GET: Invoice/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Parcel)
                .FirstOrDefaultAsync(m => m.InvoiceId == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(Guid id)
        {
            return _context.Invoice.Any(e => e.InvoiceId == id);
        }
    }
}
