using System;
using LIMSInfrastructure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LIMSWebApp.Areas.Identity.IdentityHostingStartup))]
namespace LIMSWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

                //Application Db context - users database
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("LIMSUserDbConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                    }
                    ));

                services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Stores.MaxLengthForKeys = 128;
                    // Password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = true;
                    options.Password.RequiredUniqueChars = 1;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    //sign in settings
                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                })
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 //.AddDefaultUI()
                 .AddDefaultTokenProviders();

                services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = context.Configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = context.Configuration["Authentication:Google:ClientSecret"];
                });

                //wait for Microsoft.AspNetCore.Authentication.MicrosoftAccount package upgrade to 2.1.1
                //.AddMicrosoftAccount(microsoftOptions => 
                //{
                //    microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ApplicationId"];
                //    microsoftOptions.ClientSecret = Configuration["Authentication:Miscrosoft:Password"];
                //});

                services.AddAuthorization(AuthorizationPolicy.Execute);


                //services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();


            });
        }
    }
}