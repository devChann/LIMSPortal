using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIMS.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LIMS.WebApp.Areas.Identity.Pages.UserAdmin
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<ApplicationRole> _roleManager;

		public List<SelectListItem> Roles { get; } = new List<SelectListItem>();

		public List<ApplicationUser> UsersList { get; private set; }

		public List<ApplicationRole> RolesList { get; private set; }

		public List<string> RoleNames { get; private set; } = new List<string>();

		public IndexModel(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;

			var currentRoles = roleManager.Roles.ToList();

			RolesList = currentRoles;
			UsersList = _userManager.Users.ToList();

			foreach (var role in currentRoles)
			{
				Roles.Add(new SelectListItem { Text = role.Name, Value = role.NormalizedName });
				RoleNames.Add(role.NormalizedName);
			}
		}

		
		public IActionResult OnGet()
		{
			return Page();
		}

		#region AddRolesToUsers

		[BindProperty]
		public string RoleToAdd { get; set; }
		[BindProperty]
		public string UsernameToAddRoleTo { get; set; }

		public async Task<IActionResult> OnPostAddRoleToUserAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

            //consider checking if user is logged in by userName or by email
            var user = await _userManager.FindByNameAsync(UsernameToAddRoleTo);

			if (user == null)
			{
				return Page();
			}

			var roleToUserResult = await _userManager.AddToRoleAsync(user, RoleToAdd);
			if (!roleToUserResult.Succeeded)
			{
				return StatusCode(500);
			}
			return RedirectToPage("Index");
		}

		public async Task<IActionResult> OnPostAddAllRolesToUserAsync()
		{
            //consider checking if user is logged in by userName or by email
            var user = await _userManager.FindByNameAsync(UsernameToAddRoleTo);

			if (user == null)
			{
				return Page();
			}

			foreach (var role in RoleNames)
			{
				await _userManager.AddToRoleAsync(user, role);
			}

			return RedirectToPage("Index");

		}
		#endregion

		#region RemoveRolesFromUsers

		[BindProperty]
		public string RoleToRemove { get; set; }
		[BindProperty]
		public string UsernameToRemoveRoleFrom { get; set; }

		public async Task<IActionResult> OnPostRemoveRoleFromUserAsync()
		{
			var user = await _userManager.FindByEmailAsync(UsernameToRemoveRoleFrom);

			if (user == null)
			{
				return Page();
			}

			await _userManager.RemoveFromRoleAsync(user, RoleToRemove);

			return RedirectToPage("Index");
		}
		public async Task<IActionResult> OnPostRemoveAllRolesFromUserAsync()
		{
			var user = await _userManager.FindByEmailAsync(UsernameToRemoveRoleFrom);

			if (user == null)
			{
				return Page();
			}

			foreach (var role in RoleNames)
			{
				await _userManager.RemoveFromRoleAsync(user, role);
			}

			return RedirectToPage("Index");
		}
		#endregion

		public async Task<IActionResult> OnPostDeleteRoleAsync()
		{
			var role = await _roleManager.FindByNameAsync(RoleToRemove);
			var result = await _roleManager.DeleteAsync(role);
			if (result.Succeeded)
			{
				return RedirectToPage();
			}

			return Page();
		}
	}
}
