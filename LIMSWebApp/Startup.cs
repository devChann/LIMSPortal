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
            services.AddAuthentication().AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString("Identity/Account/Login/");
                    options.AccessDeniedPath = new PathString("Identity/Account/Forbidden/");
                    options.LogoutPath = new PathString("Identity/Account/Logout/");                  
                });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Application Db context - users database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LIMSUserDbConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                }
                ));

            //LIMS Database context
            services.AddDbContext<LIMScoreContext>(options =>
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
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultUI()
            .AddDefaultTokenProviders();

            // Add application services
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });

            //SendGrid 
            services.Configure<AuthMessageSenderOptions>(Configuration);

            //Configure SendGrid 
            services.Configure<AuthMessageSenderOptions>(Configuration);

            //Configure Stripe
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //stripe configuration
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["StripeSecretKey"]);


            //loggerFactory.AddConsole();
            //env.EnvironmentName = EnvironmentName.Production;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();            
                app.UseBrowserLink();
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

            app.UseAuthentication();           

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{*id}");
            });
            //RotativaConfiguration.Setup(env);
            //create roles here
            //var serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            //CreateRoles(serviceProvider).Wait();
        }

        //public async Task CreateRoles(IServiceProvider serviceProvider)
        //{
        //    //adding custom roles         
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();     
        //    string[] roleNames = { "Admin", "Manager", "Member","Surveyor","Physical Planner","Registrer" };
            
        //    IdentityResult roleResult;

        //    foreach (var roleName in roleNames)
        //    {
        //        //creating the roles and seeding them to the database
        //        var roleExist = await RoleManager.RoleExistsAsync(roleName);
        //        if (!roleExist)
        //        {
        //            roleResult = await RoleManager.CreateAsync(new ApplicationRole(roleName));
        //        }
        //    }

        //    //creating a admin user who could maintain the web app
        //    var siteadmin = new ApplicationUser
        //    {
        //        UserName = Configuration.GetSection("AdminSettings")["AdminUserName"],
        //        Email = Configuration.GetSection("AdminSettings")["AdminEmail"]
        //    };

        //    string userPassword = Configuration.GetSection("AdminSettings")["AdminPassword"];
        //    var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AdminSettings")["AdminEmail"]);

        //    if (user == null)
        //    {
        //        var createSiteAdmin = await UserManager.CreateAsync(siteadmin, userPassword);
        //        if (createSiteAdmin.Succeeded)
        //        {
        //            //here we tie the new user to the "Admin" role 
        //            await UserManager.AddToRoleAsync(siteadmin, "Admin");

        //        }
        //    }
            
        //}
    }
}
