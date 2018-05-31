using LIMSCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace LIMSInfrastructure.Data
{
    public partial class LIMScoreContext : DbContext
    {
        public LIMScoreContext(DbContextOptions<LIMScoreContext>options):base(options)
        {

        }
        public virtual DbSet<Administration> Administration { get; set; }
        public virtual DbSet<Apartment> Apartment { get; set; }
        public virtual DbSet<Beacon> Beacon { get; set; }
        public virtual DbSet<Boundary> Boundary { get; set; }
        public virtual DbSet<BoundaryBeacon> BoundaryBeacon { get; set; }
        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<BuildingRegulations> BuildingRegulations { get; set; }
        public virtual DbSet<BuruParcels> BuruParcels { get; set; }
        public virtual DbSet<Charge> Charge { get; set; }
        public virtual DbSet<Freehold> Freehold { get; set; }
        public virtual DbSet<GroupGroupLeadership> GroupGroupLeadership { get; set; }
        public virtual DbSet<GroupGroupMembership> GroupGroupMembership { get; set; }
        public virtual DbSet<GroupLeadership> GroupLeadership { get; set; }
        public virtual DbSet<GroupLeadershipPerson> GroupLeadershipPerson { get; set; }
        public virtual DbSet<GroupMembership> GroupMembership { get; set; }
        public virtual DbSet<GroupOw> GroupOw { get; set; }
        public virtual DbSet<InsitutionLeadership> InsitutionLeadership { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<InstitutionInstitutionLeadership> InstitutionInstitutionLeadership { get; set; }
        public virtual DbSet<InstitutionLeadershipPerson> InstitutionLeadershipPerson { get; set; }
        public virtual DbSet<LandUse> LandUse { get; set; }
        public virtual DbSet<Leasehold> Leasehold { get; set; }
        public virtual DbSet<MapIndex> MapIndex { get; set; }
        public virtual DbSet<Mortgage> Mortgage { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<OwnershiRights> OwnershiRights { get; set; }
        public virtual DbSet<Parcel> Parcel { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonGroupMembership> PersonGroupMembership { get; set; }
        public virtual DbSet<Rates> Rates { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Reserve> Reserve { get; set; }
        public virtual DbSet<Responsibility> Responsibility { get; set; }
        public virtual DbSet<Restriction> Restriction { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<SpatialUnit> SpatialUnit { get; set; }
        public virtual DbSet<SpatialUnitSet> SpatialUnitSet { get; set; }
        public virtual DbSet<SpatialUnitSetRegistration> SpatialUnitSetRegistration { get; set; }
        public virtual DbSet<StaturtoryRestriction> StaturtoryRestriction { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<Tenure> Tenure { get; set; }
        public virtual DbSet<Valution> Valution { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beacon>(entity =>
            {
                entity.Property(e => e.DateSet).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<BoundaryBeacon>(entity =>
            {
                entity.HasKey(e => new { e.BoundaryId, e.BeaconId });

                entity.HasIndex(e => e.BeaconId);

                entity.HasOne(d => d.Beacon)
                    .WithMany(p => p.BoundaryBeacon)
                    .HasForeignKey(d => d.BeaconId);

                entity.HasOne(d => d.Boundary)
                    .WithMany(p => p.BoundaryBeacon)
                    .HasForeignKey(d => d.BoundaryId);
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasIndex(e => e.ApartmentId);

                entity.HasIndex(e => e.SpatialUnitId);

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Building)
                    .HasForeignKey(d => d.ApartmentId);

                entity.HasOne(d => d.SpatialUnit)
                    .WithMany(p => p.Building)
                    .HasForeignKey(d => d.SpatialUnitId);
            });

            modelBuilder.Entity<BuildingRegulations>(entity =>
            {
                entity.Property(e => e.Gcr).HasColumnName("GCR");

                entity.Property(e => e.Pcr).HasColumnName("PCR");
            });

            modelBuilder.Entity<BuruParcels>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AmountPai).HasColumnName("Amount_Pai");

                entity.Property(e => e.Boundary).HasMaxLength(30);

                entity.Property(e => e.ParcelOwn)
                    .HasColumnName("Parcel_Own")
                    .HasMaxLength(50);

                entity.Property(e => e.ShapeArea).HasColumnName("Shape_Area");

                entity.Property(e => e.ShapeLeng).HasColumnName("Shape_Leng");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Charge>(entity =>
            {
                entity.Property(e => e.Lender).HasColumnName("lender");
            });

            modelBuilder.Entity<Freehold>(entity =>
            {
                entity.HasIndex(e => e.TenureId)
                    .IsUnique();

                entity.HasOne(d => d.Tenure)
                    .WithOne(p => p.Freehold)
                    .HasForeignKey<Freehold>(d => d.TenureId);
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
                entity.HasKey(e => new { e.GroupMembershipId, e.GroupId });

                entity.HasIndex(e => e.GroupId);

                entity.HasOne(d => d.GroupMembership)
                    .WithMany(p => p.GroupGroupMembership)
                    .HasForeignKey(d => d.GroupMembershipId);
            });

            modelBuilder.Entity<GroupLeadership>(entity =>
            {
                entity.Property(e => e.LeadershipSince).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LeadershipUntil).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");
            });

            modelBuilder.Entity<GroupLeadershipPerson>(entity =>
            {
                entity.HasKey(e => new { e.GroupLeadershipId, e.PersonId });

                entity.HasIndex(e => e.PersonId);

                entity.HasOne(d => d.GroupLeadership)
                    .WithMany(p => p.GroupLeadershipPerson)
                    .HasForeignKey(d => d.GroupLeadershipId);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.GroupLeadershipPerson)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<GroupMembership>(entity =>
            {
                entity.Property(e => e.MembershipSince).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MembershipUntil).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<GroupOw>(entity =>
            {
                entity.ToTable("GroupOW");

                entity.HasIndex(e => e.OwnerId);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.GroupOw)
                    .HasForeignKey(d => d.OwnerId);
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

            modelBuilder.Entity<InstitutionLeadershipPerson>(entity =>
            {
                entity.HasKey(e => new { e.InstitutionLeadershipId, e.PersonId });

                entity.HasIndex(e => e.PersonId);

                entity.HasOne(d => d.InstitutionLeadership)
                    .WithMany(p => p.InstitutionLeadershipPerson)
                    .HasForeignKey(d => d.InstitutionLeadershipId);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.InstitutionLeadershipPerson)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<LandUse>(entity =>
            {
                entity.HasIndex(e => e.BuildingRegulationsId);

                entity.HasIndex(e => e.ZoneId);

                entity.Property(e => e.EndDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.BuildingRegulations)
                    .WithMany(p => p.LandUse)
                    .HasForeignKey(d => d.BuildingRegulationsId);

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.LandUse)
                    .HasForeignKey(d => d.ZoneId);
            });

            modelBuilder.Entity<Leasehold>(entity =>
            {
                entity.HasIndex(e => e.TenureId);

                entity.Property(e => e.LeasePeriod).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Tenure)
                    .WithMany(p => p.Leasehold)
                    .HasForeignKey(d => d.TenureId);
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasIndex(e => e.Parcelid);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Parcel)
                    .WithMany(p => p.Operation)
                    .HasForeignKey(d => d.Parcelid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Operation_Parcel");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.Pin).HasColumnName("PIN");
            });

            modelBuilder.Entity<Parcel>(entity =>
            {
                entity.HasIndex(e => e.Administrationid);

                entity.HasIndex(e => e.LandUseId);

                entity.HasIndex(e => e.OwnerId);

                entity.HasIndex(e => e.RegistrationId);

                entity.HasIndex(e => e.SpatialUnitId);

                entity.HasIndex(e => e.TenureId);

                entity.HasIndex(e => e.ValuationId);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ParcelNum).IsRequired();

                entity.HasOne(d => d.Administration)
                    .WithMany(p => p.Parcel)
                    .HasForeignKey(d => d.Administrationid)
                    .HasConstraintName("FK_Parcel_Administration");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Parcel)
                    .HasForeignKey<Parcel>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parcel_BuruParcels");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.Parcel)
                    .HasForeignKey<Parcel>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parcel_To_Rates");

                entity.HasOne(d => d.LandUse)
                    .WithMany(p => p.Parcel)
                    .HasForeignKey(d => d.LandUseId);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Parcel)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Parcel_Owners");

                entity.HasOne(d => d.OwnershipRightsNavigation)
                    .WithMany(p => p.Parcel)
                    .HasForeignKey(d => d.OwnershipRights)
                    .HasConstraintName("FK_Parcel_OwnershiRights");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.Parcel)
                    .HasForeignKey(d => d.RegistrationId);

                entity.HasOne(d => d.ResponsibilitiesNavigation)
                    .WithMany(p => p.Parcel)
                    .HasForeignKey(d => d.Responsibilities)
                    .HasConstraintName("FK_Parcel_Responsibility");

                entity.HasOne(d => d.RestrictionsNavigation)
                    .WithMany(p => p.Parcel)
                    .HasForeignKey(d => d.Restrictions)
                    .HasConstraintName("FK_Parcel_Restriction");

                entity.HasOne(d => d.SpatialUnit)
                    .WithMany(p => p.Parcel)
                    .HasForeignKey(d => d.SpatialUnitId);

                entity.HasOne(d => d.Tenure)
                    .WithMany(p => p.Parcel)
                    .HasForeignKey(d => d.TenureId);

                entity.HasOne(d => d.Valuation)
                    .WithMany(p => p.Parcel)
                    .HasForeignKey(d => d.ValuationId);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.ModeOfPayment).HasColumnType("nchar(10)");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Rateid).HasColumnName("rateid");

                entity.Property(e => e.ReceiptNo).HasColumnType("text");

                entity.HasOne(d => d.Rate)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Rateid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_To_Rates");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.OwnerId);

                entity.Property(e => e.Pin).HasColumnName("PIN");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.OwnerId);
            });

            modelBuilder.Entity<PersonGroupMembership>(entity =>
            {
                entity.HasKey(e => new { e.GroupMembershipId, e.PersonId });

                entity.HasIndex(e => e.PersonId);

                entity.HasOne(d => d.GroupMembership)
                    .WithMany(p => p.PersonGroupMembership)
                    .HasForeignKey(d => d.GroupMembershipId);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonGroupMembership)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<Rates>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.RegistrationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Restriction>(entity =>
            {
                entity.Property(e => e.ChrageId).HasColumnName("chrageId");

                entity.Property(e => e.LandUseId).HasColumnName("landUseId");

                entity.Property(e => e.Morgageid).HasColumnName("morgageid");

                entity.Property(e => e.ReserveId).HasColumnName("ReserveID");

                entity.HasOne(d => d.Chrage)
                    .WithMany(p => p.Restriction)
                    .HasForeignKey(d => d.ChrageId)
                    .HasConstraintName("FK_Restriction_Charge");

                entity.HasOne(d => d.Morgage)
                    .WithMany(p => p.Restriction)
                    .HasForeignKey(d => d.Morgageid)
                    .HasConstraintName("FK_Restriction_Mortgage");

                entity.HasOne(d => d.Reserve)
                    .WithMany(p => p.Restriction)
                    .HasForeignKey(d => d.ReserveId)
                    .HasConstraintName("FK_Restriction_Reserve");

                entity.HasOne(d => d.Statutory)
                    .WithMany(p => p.Restriction)
                    .HasForeignKey(d => d.Statutoryid)
                    .HasConstraintName("FK_Restriction_StaturtoryRestriction");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasIndex(e => e.Opid);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Opid).HasColumnName("OPid");

                entity.HasOne(d => d.Op)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.Opid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Operation");
            });

            modelBuilder.Entity<SpatialUnit>(entity =>
            {
                entity.HasIndex(e => e.BoundaryId)
                    .IsUnique();

                entity.HasIndex(e => e.MapIndexId);

                entity.HasIndex(e => e.SpatialUnitSetId);

                entity.HasIndex(e => e.SurveyClassId);

                entity.HasOne(d => d.Boundary)
                    .WithOne(p => p.SpatialUnit)
                    .HasForeignKey<SpatialUnit>(d => d.BoundaryId);

                entity.HasOne(d => d.MapIndex)
                    .WithMany(p => p.SpatialUnit)
                    .HasForeignKey(d => d.MapIndexId);

                entity.HasOne(d => d.SpatialUnitSet)
                    .WithMany(p => p.SpatialUnit)
                    .HasForeignKey(d => d.SpatialUnitSetId);

                entity.HasOne(d => d.SurveyClass)
                    .WithMany(p => p.SpatialUnit)
                    .HasForeignKey(d => d.SurveyClassId);
            });

            modelBuilder.Entity<SpatialUnitSetRegistration>(entity =>
            {
                entity.HasKey(e => new { e.RegistrationId, e.SpatialUnitSetId });

                entity.HasIndex(e => e.SpatialUnitSetId);

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.SpatialUnitSetRegistration)
                    .HasForeignKey(d => d.RegistrationId);

                entity.HasOne(d => d.SpatialUnitSet)
                    .WithMany(p => p.SpatialUnitSetRegistration)
                    .HasForeignKey(d => d.SpatialUnitSetId);
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.Property(e => e.DateOfEntry).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PdprefNo).HasColumnName("PDPRefNo");
            });

            modelBuilder.Entity<Valution>(entity =>
            {
                entity.Property(e => e.ValuationDate).HasDefaultValueSql("(getdate())");
            });
        }
    }
}
