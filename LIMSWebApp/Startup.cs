using LIMSInfrastructure.Data;
using LIMSInfrastructure.Identity;
using LIMSInfrastructure.Services;
using LIMSInfrastructure.Services.Payment;
using LIMSWebApp.Configuration.Startup;
using LIMSWebApp.Extensions;
using LIMSWebApp.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stripe;
using System;
using System.IO;
using System.Threading.Tasks;
using MpesaLib;
using LIMSInfrastructure.Services.GeoServices;

namespace LIMSCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
			HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
		public IHostingEnvironment HostingEnvironment { get; }

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

			services.AddHttpClient<IGeoService, GeoService>(options =>
			{
				options.BaseAddress = new Uri(Configuration.GetSection("ParcelsServerBaseAddress").Value);
			});



			//Add notification services
			services.AddSingleton<IEmailSender, EmailSender>();
            services.AddTransient<ISmsSender, SmsSender>();
            services.Configure<SMSoptions>(Configuration);

            
            services.AddMvc().AddNewtonsoftJson().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

			//Configure Stripe
			services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

			services.AddSingleton<IBraintreeService, BraintreeService>();
			
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
