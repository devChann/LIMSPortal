using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIMS.Core.Billing;
using LIMS.Infrastructure.Data;
using LIMS.WebApp.ViewModels.InvoiceViewModels;
using Microsoft.AspNetCore.Authorization;

namespace LIMS.WebApp.Controllers
{
	[Authorize]
	public class InvoiceController : Controller
    {
        private readonly LIMSCoreDbContext _context;

        public InvoiceController(LIMSCoreDbContext context)
        {
            _context = context;
        }		

		// GET: Invoice
		public async Task<IActionResult> Index(string parcelnum)
		{
			var Invoices = await _context.Invoice
				.Include(i => i.Parcel)
				.Include(i => i.Checkouts)
				.Where(a => a.Parcel.ParcelNum == parcelnum).ToListAsync();

			

			var InvoiceVMs = new List<InvoiceViewModel>();

			foreach(var invoice in Invoices)
			{				

				var InvoiceVM = new InvoiceViewModel
				{
					InvoiceID = invoice.InvoiceId,
					InvoiceNumber = invoice.InvoiceNumber,
					InvoiceAmount = invoice.InvoiceAmount,
					DateCreated = invoice.DateCreated,
					DateDue = invoice.DateDue,
					ParcelNumber = invoice.Parcel.ParcelNum,
					Status = GetInvoiceStatus(invoice)
				};

				InvoiceVMs.Add(InvoiceVM);

				
			}
			

			return View(InvoiceVMs);
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
				.Include(a => a.Checkouts)
                .FirstOrDefaultAsync(m => m.InvoiceId == id);

            if (invoice == null)
            {
                return NotFound();
            }			

			var InvoiceViewModel = new InvoiceViewModel
			{
				InvoiceID = invoice.InvoiceId,
				InvoiceNumber = invoice.InvoiceNumber,
				InvoiceAmount = invoice.InvoiceAmount,
				DateCreated = invoice.DateCreated,
				DateDue = invoice.DateDue,
				ParcelNumber = invoice.Parcel.ParcelNum,
				Status = GetInvoiceStatus(invoice)
			};

            return View(InvoiceViewModel);
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


		private string GetInvoiceStatus(Invoice invoice)
		{
			if (invoice.Checkouts.Any())
			{
				if (invoice.Checkouts.Sum(x => x.AmountPaid) < invoice.InvoiceAmount)
				{
					return "Not Paid";
				}
				else
				{
					return "Paid";
				}
			}
			else
			{
				return "Not Paid";
			}

		}
	}
}
