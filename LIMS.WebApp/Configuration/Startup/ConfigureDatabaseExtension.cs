using LIMS.Infrastructure.Data;
using LIMS.Infrastructure.Identity;
using LIMS.Infrastructure.Services.GeoServices;
using LIMS.Infrastructure.Services.Messaging;
using LIMS.Infrastructure.Services.Payment;
using LIMS.Infrastructure.Services.Properties;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MpesaLib;
using System;

namespace LIMS.WebApp.Configuration.Startup
{
	public static partial class ConfigureDatabaseExtension
	{
		
		public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration Configuration, IWebHostEnvironment env)
		{
			var connectionString = Configuration.GetConnectionString("SQLiteConnection").Replace("~", env.ContentRootPath);

			switch (Configuration["DatabaseProvider"].ToLowerInvariant())
			{
				case "postgres":
					services.AddDbContextPool<LIMSCoreDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection"), o => o.UseNetTopologySuite()));
					break;
				case "mssql":
					services.AddDbContextPool<LIMSCoreDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MSQLConnection")));
					break;
				default:
					connectionString = !string.IsNullOrEmpty(connectionString) ? connectionString : $"DataSource={env.ContentRootPath}\\App_Data\\LIMSCore.db";

					services.AddDbContextPool<LIMSCoreDbContext>(options => options.UseSqlite(connectionString));
					break;
			}

			return services;
		}

		public static IApplicationBuilder ConfigureDatabase(this IApplicationBuilder app)
		{
			var scope = app.ApplicationServices.CreateScope();

			var identityContext = scope.ServiceProvider.GetService<LIMSCoreDbContext>();

			LIMSCoreDbContext.SeedData(identityContext);

			return app;
		}
	}
}
