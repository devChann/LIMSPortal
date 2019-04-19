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
		
		public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
		{
			var connectionString = config.GetConnectionString("DefaultConnection").Replace("~", env.ContentRootPath);


			Action<DbContextOptionsBuilder> optionsBuilder;
			switch (config["DatabaseProvider"].ToLowerInvariant())
			{
				case "postgres":
					services.AddEntityFrameworkNpgsql();
					optionsBuilder = options => options.UseNpgsql(connectionString);
					break;
				case "mssql":
					services.AddEntityFrameworkSqlServer();
					optionsBuilder = options =>
					{
						options.UseSqlServer(connectionString);
					};
					break;
				default:
					services.AddEntityFrameworkSqlite();
					connectionString = !string.IsNullOrEmpty(connectionString) ? connectionString : $"DataSource={env.ContentRootPath}\\App_Data\\Majidata.db";
					optionsBuilder = options => options.UseSqlite(connectionString);
					break;
			}

			services.AddDbContextPool<LIMSCoreDbContext>(options => {
				optionsBuilder(options);
				options.EnableSensitiveDataLogging();
			});

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
