using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace LIMS.Infrastructure.Identity
{
	//Todo - This is a bit of a hack to ensure that there is a default admin user on first run, can probably remove when the first start wizard is implemented
	public static class SeedDefaultAdminUserToAdminRole
	{
		public static async Task Seed(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration config)
		{
			var administratorRole = "Administrator";
			var defaultAdminUsername = config["DefaultAdminSettings:AdminEmail"];
			var defaultAdminPassword = config["DefaultAdminSettings:AdminPassword"];

			var adminRoleExists = await roleManager.RoleExistsAsync(administratorRole);

			if (!adminRoleExists)
			{
				var role = new ApplicationRole()
				{
					Name = administratorRole					
				};
				_ = await roleManager.CreateAsync(role);
			}

			// If there are no users who are currently an admin, then create a default admin user
			var anyAdminUsers = await userManager.GetUsersInRoleAsync(administratorRole);

			if (!anyAdminUsers.Any())
			{
				var defaultAdminUserExists = await userManager.FindByEmailAsync(defaultAdminUsername);

				if (defaultAdminUserExists == null)
				{
					var defaultAdminUser = new ApplicationUser
					{
						UserName = defaultAdminUsername,
						Email = defaultAdminUsername,
						EmailConfirmed = true,
						FirstName = administratorRole
					};

					var userResult = await userManager.CreateAsync(defaultAdminUser, defaultAdminPassword);

					if (userResult.Succeeded)
					{
						_ = await userManager.AddToRoleAsync(defaultAdminUser, administratorRole);
					}
				}
			}
		}
	}
}
