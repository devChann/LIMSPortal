﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LIMSInfrastructure.Identity
{
    // determines the user and its role based on the primary key specified by the 
    // third parameter
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationRole>().HasData(new[]
            {
                new ApplicationRole
                {
                    Name = "Authors",
                    NormalizedName = "Authors".ToUpper()
                },
                new ApplicationRole
                {
                    Name = "Editors",
                    NormalizedName = "Editors".ToUpper()
                },
                new ApplicationRole
                {
                    Name = "Administrators",
                    NormalizedName = "Administrators".ToUpper()
                }
            });
        }

        public static void SeedData(ApplicationDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
