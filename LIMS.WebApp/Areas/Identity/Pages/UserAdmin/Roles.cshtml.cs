using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LIMS.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIMS.WebApp.Areas.Identity.Pages.UserAdmin
{
    [Authorize(Roles = "Administrators")]
    public class RolesModel : PageModel
	{
		[BindProperty]
		[Required]
		public string RoleName { get; set; }
		private readonly RoleManager<ApplicationRole> RoleManager;

		public RolesModel(RoleManager<ApplicationRole> roleManager)
		{
			RoleManager = roleManager;
		}


		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var result = await RoleManager.CreateAsync(new ApplicationRole() { Name = RoleName });
			if (result.Errors.Any())
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return Page();
			}
			return RedirectToPage("Index");
		}
	}
}
