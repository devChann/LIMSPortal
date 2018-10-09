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
		public virtual DbSet<Payment> Payment { get; set; }
		public virtual DbSet<Product> Product { get; set; }
		public virtual DbSet<Invoice> Invoice { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MpesaTransaction>(entity =>
            {
				entity.HasKey(k => k.Id);				           
            });

			modelBuilder.Entity<Payment>(entity =>
			{				
				entity.HasOne(m => m.MpesaTransaction);				
			});
			

			modelBuilder.Entity<Invoice>(entity =>
			{
				entity.HasOne(k => k.Product);
				entity.HasMany(p => p.Payments);
				
			});


		}
    }
}
