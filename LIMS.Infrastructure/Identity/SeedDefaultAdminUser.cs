using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LIMS.Infrastructure.Identity
{
	//Todo - This is a bit of a hack to ensure that there is a default admin user on first run, can probably remove when the first start wizard is implemented
	public static class SeedDefaultAdminUserToAdminRole
	{
		public static async Task Seed(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
		{
			var administratorsRole = "Administrators";
			var defaultAdminUsername = "admin@lims.co.ke";
			var defaultAdminPassword = "Admin@123";

			var adminRoleExists = await roleManager.RoleExistsAsync(administratorsRole);

			if (!adminRoleExists)
			{
				var role = new ApplicationRole()
				{
					Name = administratorsRole					
				};

				var roleResult = await roleManager.CreateAsync(role);
			}

			// If there are no users who are currently an admin, then create a default admin user
			var anyAdminUsers = await userManager.GetUsersInRoleAsync(administratorsRole);

			if (!anyAdminUsers.Any())
			{
				var defaultAdminUserExists = await userManager.FindByEmailAsync(defaultAdminUsername);

				if (defaultAdminUserExists == null)
				{
					var defaultAdminUser = new ApplicationUser
					{
						UserName = defaultAdminUsername,
						Email = defaultAdminUsername,
						EmailConfirmed = true
					};

					var userResult = await userManager.CreateAsync(defaultAdminUser, defaultAdminPassword);

					if (userResult.Succeeded)
					{
						var result = await userManager.AddToRoleAsync(defaultAdminUser, administratorsRole);
					}
				}
			}
		}
	}
}
