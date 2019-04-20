using LIMS.Infrastructure.Data;
using LIMS.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LIMS.WebApp.Pages.Tenures
{

    public class CreateModel : PageModel
	{
		private readonly LIMSCoreDbContext _db;
		public CreateModel(LIMSCoreDbContext db)
		{
			_db = db;
		}

		[TempData]
		public string Message { get; set; }

		[BindProperty]
		public Tenure Tenure { get; set; }

		public List<SelectListItem> TenureTypes { get; set; }

		public void OnGet()
		{
			TenureTypes = _db.Tenure.Select(a =>
				new SelectListItem
				{
					Value = a.TenureType,
					Text = a.TenureType
				}).ToList();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_db.Tenure.Add(Tenure);
			await _db.SaveChangesAsync();
			Message = "Tenure has been created successfully";
			return RedirectToPage("Index");
		}

	}
}
