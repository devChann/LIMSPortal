using LIMS.Infrastructure.Data;
using LIMS.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace LIMS.WebApp.Pages.Workflows
{

    public class IndexModel : PageModel
	{
		private readonly LIMSCoreDbContext _db;
		public IndexModel(LIMSCoreDbContext db)
		{
			_db = db;
		}

		[TempData]
		public string Message { get; set; }

		public IEnumerable<Tenure> Tenures { get; set; }
		
		public async Task OnGet()
		{
			Tenures = await _db.Tenure.ToListAsync();
		}

		public async Task<IActionResult> OnPostDeleteAsync(Guid id)
		{
			var tenure = await _db.Tenure.FindAsync(id);

			if(tenure == null)
			{
				return NotFound();
			}

			_db.Tenure.Remove(tenure);
			await _db.SaveChangesAsync();
			Message = "The Tenure Type been deleted successfully!";

			return RedirectToPage("Index");

		}
		
	}
}
