using LIMSInfrastructure.Data;
using LIMSInfrastructure.Identity;
using LIMSInfrastructure.Services;
using LIMSInfrastructure.Services.Payment;
using LIMSWebApp.Extensions;
using LIMSWebApp.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MpesaLib.Clients;
using MpesaLib.Interfaces;
using Serilog;
using Stripe;
using System;
using System.IO;

namespace LIMSCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug().WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "log-{Date}.txt"))
            //    .CreateLogger();
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

            services.AddCors();

            //Inject repository
            //services.AddScoped(typeof(IRepository<>), typeof(LIMSRepository<>));

            //Add Lipa na Mpesa Client
            services.AddHttpClient<IAuthClient, AuthClient>();
            services.AddHttpClient<LipaNaMpesaOnlineClient>();
            //services.AddHttpClient<C2BRegisterUrlClient>();
            //services.AddHttpClient<C2BClient>();

            
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

            //Add SignalR
            services.AddSignalR();

        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {           

            //Stripe configuration
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["StripeSecretKey"]);           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();            
               
                app.UseDatabaseErrorPage();              
            }
            else
            {
                //loggerFactory.AddSerilog();
                loggerFactory.AddFile(Path.Combine(env.ContentRootPath, "/logs/myapp-{Date}.txt"));
                app.UseExceptionHandler("/Home/Error");               
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");

            app.UseCors(builder => 
                builder.WithOrigins("https://demo.osl.co.ke:7575")
                .AllowAnyHeader()
                .AllowAnyMethod()
            );
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseSignalR(routes =>
            {
                routes.MapHub<PaymentsHub>("/hubs/payments");
            });

            app.UseMvcWithDefaultRoute();
           
        }

    }
}
