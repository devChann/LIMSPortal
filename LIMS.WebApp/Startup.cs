using LIMS.Infrastructure.Identity;
using LIMS.Infrastructure.Services.AppVersion;
using LIMS.Infrastructure.Services.Properties;
using LIMS.WebApp.Configuration.Startup;
using LIMS.WebApp.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using System;
using LIMS.Infrastructure.Data;

namespace LIMS.WebApp
{
	public class Startup
    {
		

		public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
			HostingEnvironment = hostingEnvironment;
		}

		public IConfiguration Configuration { get; }
		public IWebHostEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.ConfigureDatabase(Configuration, HostingEnvironment);

			services.ConfigureSecurityAndAuthentication();

			services.ConfigureInfrastructureServices(Configuration);

			services.Configure<IISOptions>(options =>
			{
				options.ForwardClientCertificate = false;
				options.AutomaticAuthentication = true;
			});

			services.AddCors();

			services.AddControllersWithViews()
			   .AddNewtonsoftJson();

			services.AddRazorPages();

			//services.AddMvc().AddNewtonsoftJson();

			services.AddSignalR();	

		}

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void  Configure(IApplicationBuilder app, IWebHostEnvironment env,
			UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {           

            //Stripe configuration
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["StripeSecretKey"]);			

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
				//app.UseDatabaseErrorPage();
			}
            else
            {              				
                app.UseExceptionHandler("/Home/Error");             
            }

			app.ConfigureSecurityHeaders();

			app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");      
          
            app.UseStaticFiles();

            app.UseFileServer();

			var authenticationTask = app.ConfigureAuthentication(userManager, roleManager, Configuration);

			authenticationTask.GetAwaiter().GetResult();

			//use local signalR service
			app.UseSignalR(routes =>
			{
				routes.MapHub<PaymentsHub>("/Payments");
			});


			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});

			//app.UseMvcWithDefaultRoute();

		}

    }
}
