using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIMS.WebApp.Pages.Admin
{

    public class DashboardModel : PageModel
	{
		public DashboardModel()
		{

		}
		public IActionResult OnGet()
		{
			return Page();
		}
		
	}
}
