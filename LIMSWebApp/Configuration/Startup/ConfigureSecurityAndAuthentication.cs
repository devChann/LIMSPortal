using System.Threading.Tasks;
using LIMSInfrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LIMSWebApp.Configuration.Startup
{
	public static partial class ConfigurationExtensions
	{
		public static IServiceCollection ConfigureSecurityAndAuthentication(this IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
			return services;
		}

		//public static IApplicationBuilder ConfigureSecurityHeaders(this IApplicationBuilder app)
		//{
		//	app.UseHsts(options => options.MaxAge(days: 365).IncludeSubdomains());
		//	app.UseXContentTypeOptions();
		//	app.UseReferrerPolicy(options => options.NoReferrer());
		//	app.UseXXssProtection(options => options.EnabledWithBlockMode());
		//	app.UseXfo(options => options.Deny());
		//	app.UseHttpsRedirection();
		//	return app;
		//}

		public static async Task<IApplicationBuilder> ConfigureAuthentication(this IApplicationBuilder app, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
		{
			app.UseCookiePolicy();
			app.UseAuthentication();
			await SeedDefaultAdminUserToAdminRole.Seed(userManager, roleManager);
			return app;
		}
	}
}
