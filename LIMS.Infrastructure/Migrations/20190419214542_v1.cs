using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMS.Infrastructure.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administration",
                columns: table => new
                {
                    AdministrationId = table.Column<Guid>(nullable: false),
                    BlockName = table.Column<string>(nullable: true),
                    DistrictName = table.Column<string>(nullable: true),
                    LocationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administration", x => x.AdministrationId);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    ApartmentId = table.Column<Guid>(nullable: false),
                    ApartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.ApartmentId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    Users = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    KRAPIN = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    IDNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beacon",
                columns: table => new
                {
                    BeaconId = table.Column<Guid>(nullable: false),
                    BeaconNum = table.Column<string>(nullable: true),
                    BeaconType = table.Column<string>(nullable: true),
                    DateSet = table.Column<DateTime>(nullable: false),
                    Hcoordinate = table.Column<double>(nullable: false),
                    HorizontalDatum = table.Column<string>(nullable: true),
                    VerticalDatum = table.Column<string>(nullable: true),
                    Xcoordinate = table.Column<double>(nullable: false),
                    Ycoordinate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beacon", x => x.BeaconId);
                });

            migrationBuilder.CreateTable(
                name: "Boundary",
                columns: table => new
                {
                    BoundaryId = table.Column<Guid>(nullable: false),
                    BoundaryType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boundary", x => x.BoundaryId);
                });

            migrationBuilder.CreateTable(
                name: "BuildingRegulation",
                columns: table => new
                {
                    BuildingRegulationId = table.Column<Guid>(nullable: false),
                    GCR = table.Column<double>(nullable: false),
                    PCR = table.Column<double>(nullable: false),
                    PlotFrontage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingRegulation", x => x.BuildingRegulationId);
                });

            migrationBuilder.CreateTable(
                name: "Charge",
                columns: table => new
                {
                    ChargeId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    Lender = table.Column<string>(nullable: true),
                    Ranking = table.Column<int>(nullable: false),
                    RepaymentTerm = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.ChargeId);
                });

            migrationBuilder.CreateTable(
                name: "GroupLeadership",
                columns: table => new
                {
                    GroupLeadershipId = table.Column<Guid>(nullable: false),
                    LeadershipRole = table.Column<string>(nullable: true),
                    LeadershipSince = table.Column<DateTime>(nullable: false),
                    LeadershipStatus = table.Column<string>(nullable: true),
                    LeadershipUntil = table.Column<DateTime>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLeadership", x => x.GroupLeadershipId);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembership",
                columns: table => new
                {
                    GroupMembershipId = table.Column<Guid>(nullable: false),
                    MembershipShare = table.Column<double>(nullable: false),
                    MembershipSince = table.Column<DateTime>(nullable: false),
                    MembershipStatus = table.Column<string>(nullable: true),
                    MembershipUntil = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembership", x => x.GroupMembershipId);
                });

            migrationBuilder.CreateTable(
                name: "InsitutionLeadership",
                columns: table => new
                {
                    InsitutionLeadershipId = table.Column<Guid>(nullable: false),
                    MemberSince = table.Column<DateTime>(nullable: false),
                    MemberUntil = table.Column<DateTime>(nullable: false),
                    MembershipRole = table.Column<string>(nullable: true),
                    MembershipStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsitutionLeadership", x => x.InsitutionLeadershipId);
                });

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    InstitutionId = table.Column<Guid>(nullable: false),
                    InstitutionType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.InstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "MapIndex",
                columns: table => new
                {
                    MapIndexId = table.Column<Guid>(nullable: false),
                    MapSheetNum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapIndex", x => x.MapIndexId);
                });

            migrationBuilder.CreateTable(
                name: "Mortgage",
                columns: table => new
                {
                    MortgageId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    Lender = table.Column<string>(nullable: true),
                    Ranking = table.Column<int>(nullable: false),
                    RepaymentTerm = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mortgage", x => x.MortgageId);
                });

            migrationBuilder.CreateTable(
                name: "MpesaTransaction",
                columns: table => new
                {
                    MpesaTransactionId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    CheckoutRequestID = table.Column<string>(nullable: true),
                    MerchantRequestId = table.Column<string>(nullable: true),
                    ReceiptNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpesaTransaction", x => x.MpesaTransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OwnerType = table.Column<string>(nullable: true),
                    PIN = table.Column<string>(nullable: true),
                    PostalAddress = table.Column<string>(nullable: true),
                    TelephoneAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "OwnershipRight",
                columns: table => new
                {
                    OwnershipRightId = table.Column<Guid>(nullable: false),
                    RightType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipRight", x => x.OwnershipRightId);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    RateId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.RateId);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationId = table.Column<Guid>(nullable: false),
                    Jurisdiction = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    RegistrationSection = table.Column<string>(nullable: true),
                    RegistrationType = table.Column<string>(nullable: true),
                    TitleNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                columns: table => new
                {
                    ReserveId = table.Column<Guid>(nullable: false),
                    ComplianceStatus = table.Column<string>(nullable: true),
                    EnforcingAuthority = table.Column<string>(nullable: true),
                    ReserveType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.ReserveId);
                });

            migrationBuilder.CreateTable(
                name: "Responsibility",
                columns: table => new
                {
                    ResponsibilityId = table.Column<Guid>(nullable: false),
                    PerformanceRequirement = table.Column<string>(nullable: true),
                    ResponsibilityType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibility", x => x.ResponsibilityId);
                });

            migrationBuilder.CreateTable(
                name: "SpatialUnitSet",
                columns: table => new
                {
                    SpatialUnitSetId = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpatialUnitSet", x => x.SpatialUnitSetId);
                });

            migrationBuilder.CreateTable(
                name: "StatutoryRestriction",
                columns: table => new
                {
                    StatutoryRestrictionId = table.Column<Guid>(nullable: false),
                    NatureOfRestriction = table.Column<string>(nullable: true),
                    RestrictingAuthority = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatutoryRestriction", x => x.StatutoryRestrictionId);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    SurveyId = table.Column<Guid>(nullable: false),
                    CompsNo = table.Column<string>(nullable: true),
                    DateOfEntry = table.Column<DateTime>(nullable: true),
                    PdpRefNo = table.Column<int>(nullable: false),
                    PlansNo = table.Column<string>(nullable: true),
                    SurveyorsName = table.Column<string>(nullable: true),
                    TypeOfSurvey = table.Column<string>(nullable: true),
                    ParcelNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.SurveyId);
                });

            migrationBuilder.CreateTable(
                name: "Tenure",
                columns: table => new
                {
                    TenureId = table.Column<Guid>(nullable: false),
                    TenureType = table.Column<string>(nullable: true),
                    TenureBeginDate = table.Column<DateTime>(nullable: false),
                    TenureEndDate = table.Column<DateTime>(nullable: false),
                    Lessor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenure", x => x.TenureId);
                });

            migrationBuilder.CreateTable(
                name: "Valuation",
                columns: table => new
                {
                    ValuationId = table.Column<Guid>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SerialNo = table.Column<string>(nullable: true),
                    ValuationBookNo = table.Column<string>(nullable: true),
                    ValuationDate = table.Column<DateTime>(nullable: true),
                    Value = table.Column<double>(nullable: true),
                    Valuer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valuation", x => x.ValuationId);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    ZoneId = table.Column<Guid>(nullable: false),
                    ZoneType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoundaryBeacon",
                columns: table => new
                {
                    BeaconId = table.Column<Guid>(nullable: false),
                    BoundaryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoundaryBeacon", x => new { x.BoundaryId, x.BeaconId });
                    table.ForeignKey(
                        name: "FK_BoundaryBeacon_Beacon_BeaconId",
                        column: x => x.BeaconId,
                        principalTable: "Beacon",
                        principalColumn: "BeaconId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoundaryBeacon_Boundary_BoundaryId",
                        column: x => x.BoundaryId,
                        principalTable: "Boundary",
                        principalColumn: "BoundaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionInstitutionLeadership",
                columns: table => new
                {
                    InstitutionLeadershipId = table.Column<Guid>(nullable: false),
                    InstitutionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionInstitutionLeadership", x => new { x.InstitutionLeadershipId, x.InstitutionId });
                    table.ForeignKey(
                        name: "FK_InstitutionInstitutionLeadership_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstitutionInstitutionLeadership_InsitutionLeadership_InstitutionLeadershipId",
                        column: x => x.InstitutionLeadershipId,
                        principalTable: "InsitutionLeadership",
                        principalColumn: "InsitutionLeadershipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    County = table.Column<string>(nullable: true),
                    GroupType = table.Column<string>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Group_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    PersonType = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PIN = table.Column<string>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpatialUnitSetRegistration",
                columns: table => new
                {
                    RegistrationId = table.Column<Guid>(nullable: false),
                    SpatialUnitSetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpatialUnitSetRegistration", x => new { x.RegistrationId, x.SpatialUnitSetId });
                    table.ForeignKey(
                        name: "FK_SpatialUnitSetRegistration_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpatialUnitSetRegistration_SpatialUnitSet_SpatialUnitSetId",
                        column: x => x.SpatialUnitSetId,
                        principalTable: "SpatialUnitSet",
                        principalColumn: "SpatialUnitSetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restriction",
                columns: table => new
                {
                    RestrictionId = table.Column<Guid>(nullable: false),
                    RestrictionType = table.Column<string>(nullable: true),
                    ChargeId = table.Column<Guid>(nullable: false),
                    MortgageId = table.Column<Guid>(nullable: false),
                    ReserveId = table.Column<Guid>(nullable: false),
                    StatutoryRestrictionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restriction", x => x.RestrictionId);
                    table.ForeignKey(
                        name: "FK_Restriction_Charge",
                        column: x => x.ChargeId,
                        principalTable: "Charge",
                        principalColumn: "ChargeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restriction_Mortgage",
                        column: x => x.MortgageId,
                        principalTable: "Mortgage",
                        principalColumn: "MortgageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restriction_Reserve",
                        column: x => x.ReserveId,
                        principalTable: "Reserve",
                        principalColumn: "ReserveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restriction_StatutoryRestriction",
                        column: x => x.StatutoryRestrictionId,
                        principalTable: "StatutoryRestriction",
                        principalColumn: "StatutoryRestrictionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpatialUnit",
                columns: table => new
                {
                    SpatialUnitId = table.Column<Guid>(nullable: false),
                    Area = table.Column<double>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Layer = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: true),
                    PreliminaryUnitId = table.Column<int>(nullable: false),
                    ReferencePoint = table.Column<string>(nullable: true),
                    SpatialUnitType = table.Column<string>(nullable: true),
                    Volume = table.Column<double>(nullable: true),
                    BoundaryId = table.Column<Guid>(nullable: false),
                    MapIndexId = table.Column<Guid>(nullable: false),
                    SpatialUnitSetId = table.Column<Guid>(nullable: false),
                    SurveyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpatialUnit", x => x.SpatialUnitId);
                    table.ForeignKey(
                        name: "FK_SpatialUnit_Boundary_BoundaryId",
                        column: x => x.BoundaryId,
                        principalTable: "Boundary",
                        principalColumn: "BoundaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpatialUnit_MapIndex_MapIndexId",
                        column: x => x.MapIndexId,
                        principalTable: "MapIndex",
                        principalColumn: "MapIndexId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpatialUnit_SpatialUnitSet_SpatialUnitSetId",
                        column: x => x.SpatialUnitSetId,
                        principalTable: "SpatialUnitSet",
                        principalColumn: "SpatialUnitSetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpatialUnit_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "SurveyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandUse",
                columns: table => new
                {
                    LandUseId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    LandUseStatus = table.Column<string>(nullable: true),
                    LandUseType = table.Column<string>(nullable: true),
                    RegulationAgency = table.Column<string>(nullable: true),
                    BuildingRegulationId = table.Column<Guid>(nullable: false),
                    ZoneId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandUse", x => x.LandUseId);
                    table.ForeignKey(
                        name: "FK_LandUse_BuildingRegulation_BuildingRegulationId",
                        column: x => x.BuildingRegulationId,
                        principalTable: "BuildingRegulation",
                        principalColumn: "BuildingRegulationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandUse_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupGroupLeadership",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    GroupLeadershipId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupGroupLeadership", x => new { x.GroupId, x.GroupLeadershipId });
                    table.ForeignKey(
                        name: "FK_GroupGroupLeadership_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupGroupLeadership_GroupLeadership_GroupLeadershipId",
                        column: x => x.GroupLeadershipId,
                        principalTable: "GroupLeadership",
                        principalColumn: "GroupLeadershipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupGroupMembership",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    GroupMembershipId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupGroupMembership", x => new { x.GroupId, x.GroupMembershipId });
                    table.ForeignKey(
                        name: "FK_GroupGroupMembership_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupGroupMembership_GroupMembership_GroupMembershipId",
                        column: x => x.GroupMembershipId,
                        principalTable: "GroupMembership",
                        principalColumn: "GroupMembershipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonGroupLeadership",
                columns: table => new
                {
                    GroupLeadershipId = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGroupLeadership", x => new { x.GroupLeadershipId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonGroupLeadership_GroupLeadership_GroupLeadershipId",
                        column: x => x.GroupLeadershipId,
                        principalTable: "GroupLeadership",
                        principalColumn: "GroupLeadershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonGroupLeadership_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonGroupMembership",
                columns: table => new
                {
                    GroupMembershipId = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGroupMembership", x => new { x.GroupMembershipId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonGroupMembership_GroupMembership_GroupMembershipId",
                        column: x => x.GroupMembershipId,
                        principalTable: "GroupMembership",
                        principalColumn: "GroupMembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonGroupMembership_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInstitutionLeadership",
                columns: table => new
                {
                    InstitutionLeadershipId = table.Column<Guid>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInstitutionLeadership", x => new { x.InstitutionLeadershipId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonInstitutionLeadership_InsitutionLeadership_InstitutionLeadershipId",
                        column: x => x.InstitutionLeadershipId,
                        principalTable: "InsitutionLeadership",
                        principalColumn: "InsitutionLeadershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInstitutionLeadership_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingId = table.Column<Guid>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: true),
                    ApartmentId = table.Column<Guid>(nullable: false),
                    SpatialUnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Building_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Building_SpatialUnit_SpatialUnitId",
                        column: x => x.SpatialUnitId,
                        principalTable: "SpatialUnit",
                        principalColumn: "SpatialUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcel",
                columns: table => new
                {
                    ParcelId = table.Column<Guid>(nullable: false),
                    Area = table.Column<double>(nullable: true),
                    ParcelNum = table.Column<string>(nullable: false),
                    AdministrationId = table.Column<Guid>(nullable: false),
                    LandUseId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    OwnershipRightId = table.Column<Guid>(nullable: false),
                    RateId = table.Column<Guid>(nullable: false),
                    RegistrationId = table.Column<Guid>(nullable: false),
                    ResponsibilityId = table.Column<Guid>(nullable: false),
                    RestrictionId = table.Column<Guid>(nullable: false),
                    SpatialUnitId = table.Column<Guid>(nullable: false),
                    TenureId = table.Column<Guid>(nullable: false),
                    ValuationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.ParcelId);
                    table.ForeignKey(
                        name: "FK_Parcel_Administration_AdministrationId",
                        column: x => x.AdministrationId,
                        principalTable: "Administration",
                        principalColumn: "AdministrationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_LandUse_LandUseId",
                        column: x => x.LandUseId,
                        principalTable: "LandUse",
                        principalColumn: "LandUseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_OwnershipRight_OwnershipRightId",
                        column: x => x.OwnershipRightId,
                        principalTable: "OwnershipRight",
                        principalColumn: "OwnershipRightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Rate_RateId",
                        column: x => x.RateId,
                        principalTable: "Rate",
                        principalColumn: "RateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Responsibility_ResponsibilityId",
                        column: x => x.ResponsibilityId,
                        principalTable: "Responsibility",
                        principalColumn: "ResponsibilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Restriction_RestrictionId",
                        column: x => x.RestrictionId,
                        principalTable: "Restriction",
                        principalColumn: "RestrictionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_SpatialUnit_SpatialUnitId",
                        column: x => x.SpatialUnitId,
                        principalTable: "SpatialUnit",
                        principalColumn: "SpatialUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Tenure_TenureId",
                        column: x => x.TenureId,
                        principalTable: "Tenure",
                        principalColumn: "TenureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Valuation_ValuationId",
                        column: x => x.ValuationId,
                        principalTable: "Valuation",
                        principalColumn: "ValuationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(nullable: false),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDue = table.Column<DateTime>(nullable: false),
                    ParcelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_Parcel_ParcelId",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "ParcelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    OperationId = table.Column<Guid>(nullable: false),
                    OperationName = table.Column<string>(nullable: true),
                    ParcelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operation_Parcel",
                        column: x => x.ParcelId,
                        principalTable: "Parcel",
                        principalColumn: "ParcelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    ModeOfPayment = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    ReceiptNo = table.Column<string>(nullable: true),
                    InvoiceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    Progress = table.Column<Guid>(nullable: false),
                    OperationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Service_Operation",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkout",
                columns: table => new
                {
                    CheckoutId = table.Column<Guid>(nullable: false),
                    CheckoutDate = table.Column<DateTime>(nullable: false),
                    CheckoutRequestId = table.Column<string>(nullable: true),
                    AmountPaid = table.Column<double>(nullable: false),
                    PaymentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkout", x => x.CheckoutId);
                    table.ForeignKey(
                        name: "FK_Checkout_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "6cf25225-70b9-4f45-ad2f-73bad9cc367d", "450fbb5a-2dcd-4889-803c-0f344041d5bb", "ApplicationRole", "Authors", "AUTHORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "fc65dd06-cb3a-4539-a334-737cef590fb0", "aa0cdc17-7f4a-4b20-9147-7aa41f5a9364", "ApplicationRole", "Editors", "EDITORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "d00d9831-075f-4985-9964-6cde9ad642e0", "209ebca3-3fa5-4ea6-a85d-4282c9d6a0ef", "ApplicationRole", "Administrators", "ADMINISTRATORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoundaryBeacon_BeaconId",
                table: "BoundaryBeacon",
                column: "BeaconId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_ApartmentId",
                table: "Building",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_SpatialUnitId",
                table: "Building",
                column: "SpatialUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkout_PaymentId",
                table: "Checkout",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_OwnerId",
                table: "Group",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGroupLeadership_GroupLeadershipId",
                table: "GroupGroupLeadership",
                column: "GroupLeadershipId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGroupMembership_GroupMembershipId",
                table: "GroupGroupMembership",
                column: "GroupMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionInstitutionLeadership_InstitutionId",
                table: "InstitutionInstitutionLeadership",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ParcelId",
                table: "Invoice",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_LandUse_BuildingRegulationId",
                table: "LandUse",
                column: "BuildingRegulationId");

            migrationBuilder.CreateIndex(
                name: "IX_LandUse_ZoneId",
                table: "LandUse",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_ParcelId",
                table: "Operation",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_AdministrationId",
                table: "Parcel",
                column: "AdministrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_LandUseId",
                table: "Parcel",
                column: "LandUseId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_OwnerId",
                table: "Parcel",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_OwnershipRightId",
                table: "Parcel",
                column: "OwnershipRightId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_RateId",
                table: "Parcel",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_RegistrationId",
                table: "Parcel",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_ResponsibilityId",
                table: "Parcel",
                column: "ResponsibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_RestrictionId",
                table: "Parcel",
                column: "RestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_SpatialUnitId",
                table: "Parcel",
                column: "SpatialUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_TenureId",
                table: "Parcel",
                column: "TenureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_ValuationId",
                table: "Parcel",
                column: "ValuationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_InvoiceId",
                table: "Payment",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_OwnerId",
                table: "Person",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroupLeadership_PersonId",
                table: "PersonGroupLeadership",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroupMembership_PersonId",
                table: "PersonGroupMembership",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInstitutionLeadership_PersonId",
                table: "PersonInstitutionLeadership",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_ChargeId",
                table: "Restriction",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_MortgageId",
                table: "Restriction",
                column: "MortgageId");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_ReserveId",
                table: "Restriction",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_StatutoryRestrictionId",
                table: "Restriction",
                column: "StatutoryRestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_OperationId",
                table: "Service",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpatialUnit_BoundaryId",
                table: "SpatialUnit",
                column: "BoundaryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpatialUnit_MapIndexId",
                table: "SpatialUnit",
                column: "MapIndexId");

            migrationBuilder.CreateIndex(
                name: "IX_SpatialUnit_SpatialUnitSetId",
                table: "SpatialUnit",
                column: "SpatialUnitSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SpatialUnit_SurveyId",
                table: "SpatialUnit",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpatialUnitSetRegistration_SpatialUnitSetId",
                table: "SpatialUnitSetRegistration",
                column: "SpatialUnitSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BoundaryBeacon");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Checkout");

            migrationBuilder.DropTable(
                name: "GroupGroupLeadership");

            migrationBuilder.DropTable(
                name: "GroupGroupMembership");

            migrationBuilder.DropTable(
                name: "InstitutionInstitutionLeadership");

            migrationBuilder.DropTable(
                name: "MpesaTransaction");

            migrationBuilder.DropTable(
                name: "PersonGroupLeadership");

            migrationBuilder.DropTable(
                name: "PersonGroupMembership");

            migrationBuilder.DropTable(
                name: "PersonInstitutionLeadership");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "SpatialUnitSetRegistration");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Beacon");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropTable(
                name: "GroupLeadership");

            migrationBuilder.DropTable(
                name: "GroupMembership");

            migrationBuilder.DropTable(
                name: "InsitutionLeadership");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Parcel");

            migrationBuilder.DropTable(
                name: "Administration");

            migrationBuilder.DropTable(
                name: "LandUse");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "OwnershipRight");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Responsibility");

            migrationBuilder.DropTable(
                name: "Restriction");

            migrationBuilder.DropTable(
                name: "SpatialUnit");

            migrationBuilder.DropTable(
                name: "Tenure");

            migrationBuilder.DropTable(
                name: "Valuation");

            migrationBuilder.DropTable(
                name: "BuildingRegulation");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "Charge");

            migrationBuilder.DropTable(
                name: "Mortgage");

            migrationBuilder.DropTable(
                name: "Reserve");

            migrationBuilder.DropTable(
                name: "StatutoryRestriction");

            migrationBuilder.DropTable(
                name: "Boundary");

            migrationBuilder.DropTable(
                name: "MapIndex");

            migrationBuilder.DropTable(
                name: "SpatialUnitSet");

            migrationBuilder.DropTable(
                name: "Survey");
        }
    }
}
