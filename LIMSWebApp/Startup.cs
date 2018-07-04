using LIMSInfrastructure.Data;
using LIMSInfrastructure.Identity;
using LIMSInfrastructure.Services;
using LIMSInfrastructure.Services.Payment;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MpesaLib.Clients;
using Stripe;
using System;

namespace LIMSCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

            //Inject repository
            //services.AddScoped(typeof(IRepository<>), typeof(LIMSRepository<>));

            //Add Lipa na Mpesa Client
            services.AddHttpClient<AuthClient>();
            services.AddHttpClient<LipaNaMpesaOnlineClient>();

            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            // Add application services
            services.AddSingleton<IEmailSender, EmailSender>();

            //services.AddMvc();
            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                    options.Conventions.AddPageRoute("/Identity/Account/Login", "Account/Login");
                    //options.Conventions.AddPageRoute("/Identity/Account/ConfirmEmail", "/Account/ConfirmEmail");
                });

            //Configure Stripe
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //stripe configuration
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["StripeSecretKey"]);           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();            
               
                app.UseDatabaseErrorPage();              
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");              
                app.UseHsts();
            }

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseStatusCodePagesWithReExecute("/HttpErrors/{0}");

            app.UseMvcWithDefaultRoute();
           
        }

    }
}
