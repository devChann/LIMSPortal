using LIMS.Infrastructure.Data;
using LIMS.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LIMS.WebApp.Pages.LandParcel
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
		public Parcel Parcel { get; set; }

		public List<SelectListItem> TenureTypes { get; set; }

		public void OnGet()
		{
			TenureTypes = _db.Parcel.Select(a =>
				new SelectListItem
				{
					Value = a.ParcelNum,
					Text = a.ParcelNum
				}).ToList();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_db.Parcel.Add(Parcel);
			await _db.SaveChangesAsync();
			Message = "Parcel has been created successfully";
			return RedirectToPage("Index");
		}

	}
}
