using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LIMSInfrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIMSWebApp.Areas.Identity.Pages.UserAdmin
{
    [Authorize(Roles = "Administrator")]
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
