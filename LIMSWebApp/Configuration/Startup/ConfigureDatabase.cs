using LIMSInfrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LIMSWebApp.Configuration.Startup
{
	public static partial class ConfigurationExtensions
	{
		
		public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration config)
		{
			/*services.AddEntityFrameworkSqlServer()
				.AddDbContextPool<LIMSCoreDbContext>(options => options.UseSqlServer(config.GetConnectionString("LIMSCoreDbConnection"),

                 sqlServerOptionsAction: sqlOptions =>
                 {
                     sqlOptions.EnableRetryOnFailure(
                     maxRetryCount: 5,
                     maxRetryDelay: TimeSpan.FromSeconds(30),
                     errorNumbersToAdd: null);
                 }));*/

			services.AddDbContext<LIMSCoreDbContext>(options =>
				options.UseSqlServer(config.GetConnectionString("LIMSCoreDbConnection"),
				sqlServerOptionsAction: sqlOptions =>
				{
					sqlOptions.EnableRetryOnFailure(
					maxRetryCount: 5,
					maxRetryDelay: TimeSpan.FromSeconds(30),
					errorNumbersToAdd: null);
				}
				)); 

			// db repos
			//services.AddTransient<IArticleRepository, ArticleSqliteRepository>();
			//services.AddTransient<ICommentRepository, CommentSqliteRepository>();
			//services.AddTransient<ISlugHistoryRepository, SlugHistorySqliteRepository>();

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
