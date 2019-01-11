using System;
using LIMSCore.Billing;
using LIMSCore.Entities;
using LIMSInfrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LIMSInfrastructure.Data
{
    public partial class LIMSCoreDbContext : IdentityDbContext<ApplicationUser>
	{
        public LIMSCoreDbContext()
        {
        }

        public LIMSCoreDbContext(DbContextOptions<LIMSCoreDbContext> options)
            : base(options)
        {
        }

		//Identity DbSets provide by IdentityDbContext class that this class inherits from

		//Billing DbSets
		public virtual DbSet<MpesaTransaction> MpesaTransaction { get; set; }
		public virtual DbSet<Payment> Payment { get; set; }
		public virtual DbSet<Product> Product { get; set; }
		public virtual DbSet<Invoice> Invoice { get; set; }

		//LIMS DbSets
		public virtual DbSet<Administration> Administration { get; set; }
        public virtual DbSet<Apartment> Apartment { get; set; }
        public virtual DbSet<Beacon> Beacon { get; set; }
        public virtual DbSet<Boundary> Boundary { get; set; }
        public virtual DbSet<BoundaryBeacon> BoundaryBeacon { get; set; }
        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<BuildingRegulation> BuildingRegulation { get; set; }
        public virtual DbSet<Charge> Charge { get; set; }
        public virtual DbSet<Freehold> Freehold { get; set; }
        public virtual DbSet<GroupGroupLeadership> GroupGroupLeadership { get; set; }
        public virtual DbSet<GroupGroupMembership> GroupGroupMembership { get; set; }
        public virtual DbSet<GroupLeadership> GroupLeadership { get; set; }
        public virtual DbSet<PersonGroupLeadership> PersonGroupLeadership { get; set; }
        public virtual DbSet<GroupMembership> GroupMembership { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<InsitutionLeadership> InsitutionLeadership { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<InstitutionInstitutionLeadership> InstitutionInstitutionLeadership { get; set; }
        public virtual DbSet<PersonInstitutionLeadership> PersonInstitutionLeadership { get; set; }
        public virtual DbSet<LandUse> LandUse { get; set; }
        public virtual DbSet<Leasehold> Leasehold { get; set; }
        public virtual DbSet<MapIndex> MapIndex { get; set; }
        public virtual DbSet<Mortgage> Mortgage { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<OwnershipRight> OwnershipRight { get; set; }
        public virtual DbSet<Parcel> Parcel { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonGroupMembership> PersonGroupMembership { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Reserve> Reserve { get; set; }
        public virtual DbSet<Responsibility> Responsibility { get; set; }
        public virtual DbSet<Restriction> Restriction { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<SpatialUnit> SpatialUnit { get; set; }
        public virtual DbSet<SpatialUnitSet> SpatialUnitSet { get; set; }
        public virtual DbSet<SpatialUnitSetRegistration> SpatialUnitSetRegistration { get; set; }
        public virtual DbSet<StatutoryRestriction> StatutoryRestriction { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<Tenure> Tenure { get; set; }
        public virtual DbSet<Valuation> Valuation { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }

        // Unable to generate entity type for table 'dbo.BuruParcels'. Please see the warning messages.

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=192.168.1.231;Initial Catalog=LIMSCoreDb;Persist Security Info=True;User ID=sa;Password=MobileST!!;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			//identity stuff
			modelBuilder.Entity<ApplicationRole>().HasData(new[]
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
			//end of identity stuff

			//BIlling Entities configuration
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
			//End of billing entity configutation


			//LIMS Entity configuration
			modelBuilder.Entity<Beacon>(entity =>
            {
                entity.Property(e => e.DateSet).HasDefaultValueSql("(getdate())");               
            });

            modelBuilder.Entity<BoundaryBeacon>(entity =>
            {
                entity.HasKey(e => new { e.BoundaryId, e.BeaconId });

                entity.HasIndex(e => e.BeaconId);
               
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasIndex(e => e.ApartmentId);

                entity.HasIndex(e => e.SpatialUnitId);

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Building)
                    .HasForeignKey(d => d.ApartmentId);

               
            });

            modelBuilder.Entity<BuildingRegulation>(entity =>
            {
                entity.Property(e => e.GCR).HasColumnName("GCR");

                entity.Property(e => e.PCR).HasColumnName("PCR");
            });

            modelBuilder.Entity<Charge>(entity =>
            {
                entity.Property(e => e.Lender).HasColumnName("lender");
            });

            modelBuilder.Entity<Freehold>(entity =>
            {
                entity.HasIndex(e => e.TenureId)
                    .IsUnique();
               
            });

            modelBuilder.Entity<GroupGroupLeadership>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.GroupLeadershipId });

                entity.HasIndex(e => e.GroupLeadershipId);

                entity.HasOne(d => d.GroupLeadership)
                    .WithMany(p => p.GroupGroupLeadership)
                    .HasForeignKey(d => d.GroupLeadershipId);
            });

            modelBuilder.Entity<GroupGroupMembership>(entity =>
            {                
               
            });

            modelBuilder.Entity<GroupLeadership>(entity =>
            {
                entity.Property(e => e.LeadershipSince).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LeadershipUntil).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PersonId).HasColumnName("PersonId");
            });

            modelBuilder.Entity<PersonGroupLeadership>(entity =>
            {
                entity.HasKey(e => new { e.GroupLeadershipId, e.PersonId });

                entity.HasIndex(e => e.PersonId);
               
            });

            modelBuilder.Entity<GroupMembership>(entity =>
            {
                entity.Property(e => e.MembershipSince).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MembershipUntil).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");
                entity.HasIndex(e => e.OwnerId);              
            });

            modelBuilder.Entity<InsitutionLeadership>(entity =>
            {
                entity.Property(e => e.MemberSince).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MemberUntil).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<InstitutionInstitutionLeadership>(entity =>
            {
                entity.HasKey(e => new { e.InstitutionLeadershipId, e.InstitutionId });

                entity.HasIndex(e => e.InstitutionId);

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.InstitutionInstitutionLeadership)
                    .HasForeignKey(d => d.InstitutionId);

                entity.HasOne(d => d.InstitutionLeadership)
                    .WithMany(p => p.InstitutionInstitutionLeadership)
                    .HasForeignKey(d => d.InstitutionLeadershipId);
            });

            modelBuilder.Entity<PersonInstitutionLeadership>(entity =>
            {
                entity.HasKey(e => new { e.InstitutionLeadershipId, e.PersonId });

                entity.HasIndex(e => e.PersonId);
               
            });

            modelBuilder.Entity<LandUse>(entity =>
            {
                entity.HasIndex(e => e.BuildingRegulationId);

                entity.HasIndex(e => e.ZoneId);

                entity.Property(e => e.EndDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.BuildingRegulation)
                    .WithMany(p => p.LandUses)
                    .HasForeignKey(d => d.BuildingRegulationId);

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.LandUses)
                    .HasForeignKey(d => d.ZoneId);
            });

            modelBuilder.Entity<Leasehold>(entity =>
            {
                entity.HasIndex(e => e.TenureId);

                entity.Property(e => e.LeasePeriod).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Tenure)
                    .WithMany(p => p.Leaseholds)
                    .HasForeignKey(d => d.TenureId);
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasIndex(e => e.ParcelId);

                entity.Property(e => e.OperationId).ValueGeneratedNever();

                entity.HasOne(d => d.Parcel)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.ParcelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Operation_Parcel");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.PIN).HasColumnName("PIN");
            });

            modelBuilder.Entity<Parcel>(entity =>
            {
                

                entity.Property(e => e.ParcelNum).IsRequired();

			});

            modelBuilder.Entity<Payments>(entity =>
            {
                //entity.Property(e => e.PaymentsId).HasColumnName("Id");

                //entity.Property(e => e.Amount).HasColumnType("money");

                //entity.Property(e => e.ModeOfPayment).HasMaxLength(10);

                //entity.Property(e => e.PaymentDate)
                //    .HasColumnType("datetime")
                //    .HasDefaultValueSql("(getdate())");

                //entity.Property(e => e.ReceiptNo).HasColumnType("text");

                //entity.HasOne(d => d.Parcel)
                //    .WithMany(p => p.Payments)
                //    .HasForeignKey(d => d.ParcelId)
                //    .HasConstraintName("FK_Payments_Parcel");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                //entity.HasIndex(e => e.OwnerId);

                //entity.Property(e => e.PIN).HasColumnName("PIN");

                //entity.HasOne(d => d.Owner)
                //    .WithMany(p => p.Persons)
                //    .HasForeignKey(d => d.OwnerId);
            });

            modelBuilder.Entity<PersonGroupMembership>(entity =>
            {
                //entity.HasKey(e => new { e.GroupMembershipId, e.PersonId });

                //entity.HasIndex(e => e.PersonId);

                //entity.HasOne(d => d.GroupMembership)
                //    .WithMany(p => p.PersonGroupMemberships)
                //    .HasForeignKey(d => d.GroupMembershipId);

                //entity.HasOne(d => d.Person)
                //    .WithMany(p => p.PersonGroupMemberships)
                //    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<Rate>(entity =>
            {
				entity.Property(e => e.RateId)
					.ValueGeneratedNever();

				entity.Property(e => e.Amount).HasColumnType("money");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.RegistrationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Restriction>(entity =>
            {
                entity.HasIndex(e => e.ChargeId);

                entity.HasIndex(e => e.MortgageId);

                entity.HasIndex(e => e.ReserveId);

                entity.HasIndex(e => e.StatutoryRestrictionId);

                entity.Property(e => e.ChargeId).HasColumnName("ChargeId");               

                entity.Property(e => e.MortgageId).HasColumnName("MortgageId");

                entity.Property(e => e.ReserveId).HasColumnName("ReserveId");

                entity.HasOne(d => d.Charge)
                    .WithMany(p => p.Restrictions)
                    .HasForeignKey(d => d.ChargeId)
                    .HasConstraintName("FK_Restriction_Charge");

                entity.HasOne(d => d.Mortgage)
                    .WithMany(p => p.Restrictions)
                    .HasForeignKey(d => d.MortgageId)
                    .HasConstraintName("FK_Restriction_Mortgage");

                entity.HasOne(d => d.Reserve)
                    .WithMany(p => p.Restrictions)
                    .HasForeignKey(d => d.ReserveId)
                    .HasConstraintName("FK_Restriction_Reserve");

                entity.HasOne(d => d.StatutoryRestriction)
                    .WithMany(p => p.Restrictions)
                    .HasForeignKey(d => d.StatutoryRestrictionId)
                    .HasConstraintName("FK_Restriction_StatutoryRestriction");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasIndex(e => e.OperationId);

                entity.Property(e => e.ServiceId).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.OperationId).HasColumnName("OperationId");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Operation");
            });

            modelBuilder.Entity<SpatialUnit>(entity =>
            {
                entity.HasIndex(e => e.BoundaryId)
                    .IsUnique();

                entity.HasIndex(e => e.MapIndexId);

                entity.HasIndex(e => e.SpatialUnitSetId);

                entity.HasIndex(e => e.SurveyId);

                entity.HasOne(d => d.Boundary)
                    .WithOne(p => p.SpatialUnit)
                    .HasForeignKey<SpatialUnit>(d => d.BoundaryId);

                entity.HasOne(d => d.MapIndex)
                    .WithMany(p => p.SpatialUnits)
                    .HasForeignKey(d => d.MapIndexId);

                entity.HasOne(d => d.SpatialUnitSet)
                    .WithMany(p => p.SpatialUnits)
                    .HasForeignKey(d => d.SpatialUnitSetId);

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SpatialUnits)
                    .HasForeignKey(d => d.SurveyId);
            });

            modelBuilder.Entity<SpatialUnitSetRegistration>(entity =>
            {
                entity.HasKey(e => new { e.RegistrationId, e.SpatialUnitSetId });

                entity.HasIndex(e => e.SpatialUnitSetId);

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.SpatialUnitSetRegistrations)
                    .HasForeignKey(d => d.RegistrationId);

                entity.HasOne(d => d.SpatialUnitSet)
                    .WithMany(p => p.SpatialUnitSetRegistrations)
                    .HasForeignKey(d => d.SpatialUnitSetId);
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.Property(e => e.DateOfEntry).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PdpRefNo).HasColumnName("PDPRefNo");
            });

            modelBuilder.Entity<Valuation>(entity =>
            {
                entity.Property(e => e.ValuationDate).HasDefaultValueSql("(getdate())");
            });
        }

		public static void SeedData(LIMSCoreDbContext context)
		{
			context.Database.Migrate();
		}
	}
}
