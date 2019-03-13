using LIMS.Infrastructure.Data;
using LIMS.Infrastructure.Services.GeoServices;
using LIMS.Infrastructure.Services.Messaging;
using LIMS.Infrastructure.Services.Payment;
using LIMS.Infrastructure.Services.Properties;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MpesaLib;
using System;

namespace LIMS.WebApp.Configuration.Startup
{
	public static partial class ConfigurationExtensions
	{
		
		public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration config)
		{		
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


			return services;
		}

		public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration config)
		{
			//change this to use RequestEndPoint.LiveBaseAddress when deploying to proction
			services.AddHttpClient<IMpesaClient, MpesaClient>(options => options.BaseAddress = RequestEndPoint.SandboxBaseAddress);

			services.Configure<SMSoptions>(config);

			//Add notification services
			services.AddSingleton<IEmailSender, EmailSender>();
			services.AddTransient<ISmsSender, SmsSender>();

			//Application Services
			services.AddHttpClient<IGeoService, GeoService>(options =>
			{
				options.BaseAddress = new Uri(config.GetSection("ParcelsServerBaseAddress").Value);
			});

			services.AddScoped<IParcelService, ParcelService>();

			//Configure Stripe
			services.Configure<StripeSettings>(config.GetSection("Stripe"));

			services.AddSingleton<IBraintreeService, BraintreeService>();

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
