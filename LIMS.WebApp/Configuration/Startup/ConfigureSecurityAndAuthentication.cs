using System;
using System.Threading.Tasks;
using LIMS.Infrastructure.Data;
using LIMS.Infrastructure.Identity;
using LIMS.WebApp.Areas.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LIMS.WebApp.Configuration.Startup
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

			services.AddDefaultIdentity<ApplicationUser>(options =>
			{
				options.Stores.MaxLengthForKeys = 128;
				// Password settings
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = true;
				options.Password.RequiredUniqueChars = 1;

				// Lockout settings
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;

				//sign in settings
				options.SignIn.RequireConfirmedEmail = true;
				options.SignIn.RequireConfirmedPhoneNumber = false;

			})
				.AddRoles<ApplicationRole>()
				.AddDefaultUI(UIFramework.Bootstrap4)
				.AddEntityFrameworkStores<LIMSCoreDbContext>()
				.AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Identity/Account/Login";
				options.LogoutPath = "/Identity/Account/Logout";
				options.AccessDeniedPath = "/Identity/Account/AccessDenied";
				options.SlidingExpiration = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
			});

			//services.AddAuthentication()
			//.AddGoogle(googleOptions =>
			//{
			//	googleOptions.ClientId = context.Configuration["Authentication:Google:ClientId"];
			//	googleOptions.ClientSecret = context.Configuration["Authentication:Google:ClientSecret"];
			//})
			//.AddMicrosoftAccount(microsoftOptions =>
			//{
			//	microsoftOptions.ClientId = context.Configuration["Authentication:Microsoft:ApplicationId"];
			//	microsoftOptions.ClientSecret = context.Configuration["Authentication:Miscrosoft:Password"];
			//});

			services.AddAuthorization(AuthorizationPolicy.Execute);

			return services;
		}

		public static IApplicationBuilder ConfigureSecurityHeaders(this IApplicationBuilder app)
		{
			app.UseHsts(options => options.MaxAge(minutes: 1));
			app.UseXContentTypeOptions();
			app.UseReferrerPolicy(options => options.NoReferrer());
			app.UseXXssProtection(options => options.EnabledWithBlockMode());
			app.UseXfo(options => options.Deny());
			app.UseHttpsRedirection();
			return app;
		}

		public static async Task<IApplicationBuilder> ConfigureAuthentication(this IApplicationBuilder app, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration config)
		{
			app.UseCookiePolicy();
			app.UseAuthentication();
			await SeedDefaultAdminUserToAdminRole.Seed(userManager, roleManager, config);
			return app;
		}
	}
}
