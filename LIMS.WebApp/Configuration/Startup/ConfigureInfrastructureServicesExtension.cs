using LIMS.Infrastructure.Data;
using LIMS.Infrastructure.Services.AppVersion;
using LIMS.Infrastructure.Services.GeoServices;
using LIMS.Infrastructure.Services.Messaging;
using LIMS.Infrastructure.Services.Payment;
using LIMS.Infrastructure.Services.Properties;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MpesaLib;
using System;

namespace LIMS.WebApp.Configuration.Startup
{
	public static partial class ConfigureInfrastructureServicesExtension
	{
	
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

			services.AddTransient<IAppVersionService, AppVersionService>();

			services.AddScoped<IParcelService, ParcelService>();

			return services;
		}

	}
}
