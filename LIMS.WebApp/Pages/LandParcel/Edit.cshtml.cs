using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIMS.WebApp.Pages.LandParcel
{

    public class EditModel : PageModel
	{
		public EditModel()
		{

		}
		public IActionResult OnGet()
		{
			return Page();
		}
		
	}
}
