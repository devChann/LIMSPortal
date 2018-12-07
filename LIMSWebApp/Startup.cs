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
using MpesaLib.Interfaces;
using MpesaLib.Clients;
using Serilog;


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
            //LIMS Database context
            services.AddDbContext<LIMSCoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LIMSCoreDbConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                }
            ));

            //Billing Database context
            services.AddDbContext<BillingDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LIMSBillingDbConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                }
            ));

            //services.AddCors();

			if (HostingEnvironment.IsDevelopment())
			{
				services.AddHttpClient<IMpesaClient, MpesaClient>(options => options.BaseAddress = new Uri("https://sandbox.safaricom.co.ke/"));
			}
			else
			{
				services.AddHttpClient<IMpesaClient, MpesaClient>(options => options.BaseAddress = new Uri("https://api.safaricom.co.ke/"));
			}

			

            services.ConfigureSecurityAndAuthentication();

			services.Configure<IISOptions>(options =>
			{
				options.ForwardClientCertificate = false;
				options.AutomaticAuthentication = true;
			});

			services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/sign-in";
                options.LogoutPath = "/account/logged-out";
                options.AccessDeniedPath = "/access-denied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            });

            //Add notification services
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddTransient<ISmsSender, SmsSender>();
            services.Configure<SMSoptions>(Configuration);

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);            

            //Configure Stripe
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

			
			services.AddSignalR(); 

			

        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void  Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {           

            //Stripe configuration
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["StripeSecretKey"]);			

            if (HostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();            
               
                app.UseDatabaseErrorPage();              
            }
            else
            {              				
                app.UseExceptionHandler("/Home/Error");               
              
				app.ConfigureSecurityHeaders();
            }

            app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");

           /* app.UseCors(builder => 
                builder.WithOrigins("https://demo.osl.co.ke:7574")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                
            );*/
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseCookiePolicy();
            //app.UseAuthentication();

			var authenticationTask = app.ConfigureAuthentication(userManager, roleManager);

			authenticationTask.GetAwaiter().GetResult();

            app.UseFileServer();


			//use local signalR service
			app.UseSignalR(routes =>
			{
				routes.MapHub<PaymentsHub>("/Payments");
			});

			//Use Azure signalR service
			//app.UseAzureSignalR(routes =>
   //         {
   //             routes.MapHub<PaymentsHub>("/hubs/payments");
   //         });

            app.UseMvcWithDefaultRoute();
           
        }

    }
}
