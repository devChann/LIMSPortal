using LIMS.Infrastructure.Identity;
using LIMS.Infrastructure.Services.GeoServices;
using LIMS.Infrastructure.Services.Messaging;
using LIMS.Infrastructure.Services.Payment;
using LIMS.Infrastructure.Services.Property;
using LIMS.WebApp.Configuration.Startup;
using LIMS.WebApp.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MpesaLib;
using Stripe;
using System;

namespace LIMS.WebApp
{
	public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
			HostingEnvironment = hostingEnvironment;		

		}

        public IConfiguration Configuration { get; }
		public IHostEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

			services.ConfigureDatabase(Configuration);

			services.AddCors();

			//change this to use https://api.safaricom.co.ke/ when deploying to proction
			services.AddHttpClient<IMpesaClient, MpesaClient>(options => options.BaseAddress = new Uri("https://sandbox.safaricom.co.ke/"));

            services.ConfigureSecurityAndAuthentication();
			

			services.Configure<IISOptions>(options =>
			{
				options.ForwardClientCertificate = false;
				options.AutomaticAuthentication = true;
			});

			services.Configure<SMSoptions>(Configuration);

			



			//Add notification services
			services.AddSingleton<IEmailSender, EmailSender>();
            services.AddTransient<ISmsSender, SmsSender>();


			//Application Services
			services.AddHttpClient<IGeoService, GeoService>(options =>
			{
				options.BaseAddress = new Uri(Configuration.GetSection("ParcelsServerBaseAddress").Value);
			});

			services.AddScoped<IParcelService, ParcelService>();           
           

			//Configure Stripe
			services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

			services.AddSingleton<IBraintreeService, BraintreeService>();

			services.AddMvc().AddNewtonsoftJson().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

			services.AddSignalR();	

		}

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void  Configure(IApplicationBuilder app, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {           

            //Stripe configuration
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["StripeSecretKey"]);			

            if (HostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();			

				//app.useDatabaseErrorPage();             
            }
            else
            {              				
                app.UseExceptionHandler("/Home/Error");             
              
				app.ConfigureSecurityHeaders();
            }

            app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");           
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();			

			var authenticationTask = app.ConfigureAuthentication(userManager, roleManager);

			authenticationTask.GetAwaiter().GetResult();

            app.UseFileServer();


			//use local signalR service
			app.UseSignalR(routes =>
			{
				routes.MapHub<PaymentsHub>("/Payments");
			});
			

            app.UseMvc(routes =>
			{		
				routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
			});
           
        }

    }
}
