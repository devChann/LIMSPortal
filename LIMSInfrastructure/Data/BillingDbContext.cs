using System;
using LIMSCore.Billing;
using LIMSCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LIMSInfrastructure.Data
{
    public partial class BillingDbContext : DbContext
    {
        public BillingDbContext()
        {
        }

        public BillingDbContext(DbContextOptions<BillingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MpesaTransaction> MpesaTransaction { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MpesaTransaction>(entity =>
            {
                entity.HasKey(k => k.Id);              
            });

            
        }
    }
}
