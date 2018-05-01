﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LIMSInfrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlockName = table.Column<string>(nullable: true),
                    DistrictName = table.Column<string>(nullable: true),
                    LocationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beacon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeaconNum = table.Column<string>(nullable: true),
                    BeaconType = table.Column<string>(nullable: true),
                    DateSet = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Hcoordinate = table.Column<double>(nullable: false),
                    HorizontalDatum = table.Column<string>(nullable: true),
                    VerticalDatum = table.Column<string>(nullable: true),
                    Xcoordinate = table.Column<double>(nullable: false),
                    Ycoordinate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beacon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boundary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoundaryType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boundary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingRegulations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GCR = table.Column<double>(nullable: false),
                    PCR = table.Column<double>(nullable: false),
                    PlotFrontage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingRegulations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuruParcels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Amount_Pai = table.Column<int>(nullable: true),
                    Area2 = table.Column<double>(nullable: true),
                    Boundary = table.Column<string>(maxLength: 30, nullable: true),
                    Geometry = table.Column<byte[]>(nullable: true),
                    Parcel_Own = table.Column<string>(maxLength: 50, nullable: true),
                    Shape_Area = table.Column<double>(nullable: true),
                    Shape_Leng = table.Column<double>(nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuruParcels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Charge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    lender = table.Column<string>(nullable: true),
                    Ranking = table.Column<int>(nullable: false),
                    RepaymentTerm = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupLeadership",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadershipRole = table.Column<string>(nullable: true),
                    LeadershipSince = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    LeadershipStatus = table.Column<string>(nullable: true),
                    LeadershipUntil = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    PersonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLeadership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembership",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MembershipShare = table.Column<double>(nullable: false),
                    MembershipSince = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    MembershipStatus = table.Column<string>(nullable: true),
                    MembershipUntil = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsitutionLeadership",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberSince = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    MemberUntil = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    MembershipRole = table.Column<string>(nullable: true),
                    MembershipStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsitutionLeadership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstitutionType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapIndex",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MapSheetNum = table.Column<string>(nullable: true),
                    ParcelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapIndex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mortgage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    BuildingId = table.Column<string>(nullable: true),
                    InterestRate = table.Column<double>(nullable: false),
                    Lender = table.Column<string>(nullable: true),
                    Ranking = table.Column<int>(nullable: false),
                    RepaymentTerm = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mortgage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OwnerType = table.Column<string>(nullable: true),
                    PIN = table.Column<string>(nullable: true),
                    PostalAddress = table.Column<string>(nullable: true),
                    TelephoneAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnershiRights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RightType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershiRights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Jurisdiction = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "(getdate())"),
                    RegistrationSection = table.Column<string>(nullable: true),
                    RegistrationType = table.Column<string>(nullable: true),
                    TitleNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComplianceStatus = table.Column<string>(nullable: true),
                    EnforcingAuthority = table.Column<string>(nullable: true),
                    ReserveType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsibility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PerformanceRequirement = table.Column<string>(nullable: true),
                    ResponsibilityType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpatialUnitSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpatialUnitSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaturtoryRestriction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NatureOfRestriction = table.Column<string>(nullable: true),
                    RestrictingAuthority = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaturtoryRestriction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompsNo = table.Column<string>(nullable: true),
                    DateOfEntry = table.Column<DateTime>(nullable: true, defaultValueSql: "(getdate())"),
                    ParcelId = table.Column<int>(nullable: false),
                    PDPRefNo = table.Column<int>(nullable: false),
                    PlansNo = table.Column<string>(nullable: true),
                    SurveyorsName = table.Column<string>(nullable: true),
                    TypeOfSurvey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenureType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Valution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remarks = table.Column<string>(nullable: true),
                    SerialNo = table.Column<string>(nullable: true),
                    ValuationBookNo = table.Column<string>(nullable: true),
                    ValuationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "(getdate())"),
                    Value = table.Column<double>(nullable: true),
                    Valuer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegulationId = table.Column<int>(nullable: false),
                    ZoneType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoundaryBeacon",
                columns: table => new
                {
                    BoundaryId = table.Column<int>(nullable: false),
                    BeaconId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoundaryBeacon", x => new { x.BoundaryId, x.BeaconId });
                    table.ForeignKey(
                        name: "FK_BoundaryBeacon_Beacon_BeaconId",
                        column: x => x.BeaconId,
                        principalTable: "Beacon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoundaryBeacon_Boundary_BoundaryId",
                        column: x => x.BoundaryId,
                        principalTable: "Boundary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupGroupLeadership",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    GroupLeadershipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupGroupLeadership", x => new { x.GroupId, x.GroupLeadershipId });
                    table.ForeignKey(
                        name: "FK_GroupGroupLeadership_GroupLeadership_GroupLeadershipId",
                        column: x => x.GroupLeadershipId,
                        principalTable: "GroupLeadership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupGroupMembership",
                columns: table => new
                {
                    GroupMembershipId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupGroupMembership", x => new { x.GroupMembershipId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GroupGroupMembership_GroupMembership_GroupMembershipId",
                        column: x => x.GroupMembershipId,
                        principalTable: "GroupMembership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionInstitutionLeadership",
                columns: table => new
                {
                    InstitutionLeadershipId = table.Column<int>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionInstitutionLeadership", x => new { x.InstitutionLeadershipId, x.InstitutionId });
                    table.ForeignKey(
                        name: "FK_InstitutionInstitutionLeadership_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstitutionInstitutionLeadership_InsitutionLeadership_InstitutionLeadershipId",
                        column: x => x.InstitutionLeadershipId,
                        principalTable: "InsitutionLeadership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupOW",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    County = table.Column<string>(nullable: true),
                    GroupType = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOW", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupOW_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    PersonType = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PIN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    ModeOfPayment = table.Column<string>(type: "nchar(10)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    rateid = table.Column<int>(nullable: false),
                    ReceiptNo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Payments_To_Rates",
                        column: x => x.rateid,
                        principalTable: "Rates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpatialUnitSetRegistration",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(nullable: false),
                    SpatialUnitSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpatialUnitSetRegistration", x => new { x.RegistrationId, x.SpatialUnitSetId });
                    table.ForeignKey(
                        name: "FK_SpatialUnitSetRegistration_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpatialUnitSetRegistration_SpatialUnitSet_SpatialUnitSetId",
                        column: x => x.SpatialUnitSetId,
                        principalTable: "SpatialUnitSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restriction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    chrageId = table.Column<int>(nullable: true),
                    landUseId = table.Column<int>(nullable: true),
                    morgageid = table.Column<int>(nullable: true),
                    ReserveID = table.Column<int>(nullable: true),
                    RestrictionType = table.Column<string>(nullable: true),
                    Statutoryid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restriction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restriction_Charge",
                        column: x => x.chrageId,
                        principalTable: "Charge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restriction_Mortgage",
                        column: x => x.morgageid,
                        principalTable: "Mortgage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restriction_Reserve",
                        column: x => x.ReserveID,
                        principalTable: "Reserve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restriction_StaturtoryRestriction",
                        column: x => x.Statutoryid,
                        principalTable: "StaturtoryRestriction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpatialUnit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<double>(nullable: true),
                    BoundaryId = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Layer = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: true),
                    MapIndexId = table.Column<int>(nullable: false),
                    PreliminaryUnitId = table.Column<int>(nullable: false),
                    ReferencePoint = table.Column<string>(nullable: true),
                    SpatialUnitSetId = table.Column<int>(nullable: false),
                    SpatialUnitType = table.Column<string>(nullable: true),
                    SurveyClassId = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpatialUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpatialUnit_Boundary_BoundaryId",
                        column: x => x.BoundaryId,
                        principalTable: "Boundary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpatialUnit_MapIndex_MapIndexId",
                        column: x => x.MapIndexId,
                        principalTable: "MapIndex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpatialUnit_SpatialUnitSet_SpatialUnitSetId",
                        column: x => x.SpatialUnitSetId,
                        principalTable: "SpatialUnitSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpatialUnit_Survey_SurveyClassId",
                        column: x => x.SurveyClassId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Freehold",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freehold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freehold_Tenure_TenureId",
                        column: x => x.TenureId,
                        principalTable: "Tenure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leasehold",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeasePeriod = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    Lessor = table.Column<string>(nullable: true),
                    TenureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leasehold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leasehold_Tenure_TenureId",
                        column: x => x.TenureId,
                        principalTable: "Tenure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandUse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildingRegulationsId = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true, defaultValueSql: "(getdate())"),
                    LandUseStatus = table.Column<string>(nullable: true),
                    LandUseType = table.Column<string>(nullable: true),
                    RegulationAgency = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true, defaultValueSql: "(getdate())"),
                    ZoneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandUse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandUse_BuildingRegulations_BuildingRegulationsId",
                        column: x => x.BuildingRegulationsId,
                        principalTable: "BuildingRegulations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LandUse_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupLeadershipPerson",
                columns: table => new
                {
                    GroupLeadershipId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLeadershipPerson", x => new { x.GroupLeadershipId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_GroupLeadershipPerson_GroupLeadership_GroupLeadershipId",
                        column: x => x.GroupLeadershipId,
                        principalTable: "GroupLeadership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupLeadershipPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionLeadershipPerson",
                columns: table => new
                {
                    InstitutionLeadershipId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionLeadershipPerson", x => new { x.InstitutionLeadershipId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_InstitutionLeadershipPerson_InsitutionLeadership_InstitutionLeadershipId",
                        column: x => x.InstitutionLeadershipId,
                        principalTable: "InsitutionLeadership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstitutionLeadershipPerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonGroupMembership",
                columns: table => new
                {
                    GroupMembershipId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGroupMembership", x => new { x.GroupMembershipId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonGroupMembership_GroupMembership_GroupMembershipId",
                        column: x => x.GroupMembershipId,
                        principalTable: "GroupMembership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonGroupMembership_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApartmentId = table.Column<int>(nullable: false),
                    SpatialUnitId = table.Column<int>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Building_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Building_SpatialUnit_SpatialUnitId",
                        column: x => x.SpatialUnitId,
                        principalTable: "SpatialUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Administrationid = table.Column<int>(nullable: false),
                    Area = table.Column<double>(nullable: true),
                    LandUseId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    OwnershipRights = table.Column<int>(nullable: false),
                    ParcelNum = table.Column<string>(nullable: false),
                    RegistrationId = table.Column<int>(nullable: false),
                    Responsibilities = table.Column<int>(nullable: false),
                    Restrictions = table.Column<int>(nullable: false),
                    SpatialUnitId = table.Column<int>(nullable: false),
                    TenureId = table.Column<int>(nullable: false),
                    ValuationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcel_Administration",
                        column: x => x.Administrationid,
                        principalTable: "Administration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_BuruParcels",
                        column: x => x.Id,
                        principalTable: "BuruParcels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcel_To_Rates",
                        column: x => x.Id,
                        principalTable: "Rates",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcel_LandUse_LandUseId",
                        column: x => x.LandUseId,
                        principalTable: "LandUse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Owners",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_OwnershiRights",
                        column: x => x.OwnershipRights,
                        principalTable: "OwnershiRights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Responsibility",
                        column: x => x.Responsibilities,
                        principalTable: "Responsibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Restriction",
                        column: x => x.Restrictions,
                        principalTable: "Restriction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_SpatialUnit_SpatialUnitId",
                        column: x => x.SpatialUnitId,
                        principalTable: "SpatialUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Tenure_TenureId",
                        column: x => x.TenureId,
                        principalTable: "Tenure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcel_Valution_ValuationId",
                        column: x => x.ValuationId,
                        principalTable: "Valution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Parcelid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_Parcel",
                        column: x => x.Parcelid,
                        principalTable: "Parcel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    OPid = table.Column<int>(nullable: false),
                    Progress = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Operation",
                        column: x => x.OPid,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Freehold_TenureId",
                table: "Freehold",
                column: "TenureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupGroupLeadership_GroupLeadershipId",
                table: "GroupGroupLeadership",
                column: "GroupLeadershipId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGroupMembership_GroupId",
                table: "GroupGroupMembership",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLeadershipPerson_PersonId",
                table: "GroupLeadershipPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOW_OwnerId",
                table: "GroupOW",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionInstitutionLeadership_InstitutionId",
                table: "InstitutionInstitutionLeadership",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionLeadershipPerson_PersonId",
                table: "InstitutionLeadershipPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LandUse_BuildingRegulationsId",
                table: "LandUse",
                column: "BuildingRegulationsId");

            migrationBuilder.CreateIndex(
                name: "IX_LandUse_ZoneId",
                table: "LandUse",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Leasehold_TenureId",
                table: "Leasehold",
                column: "TenureId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_Parcelid",
                table: "Operation",
                column: "Parcelid");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_Administrationid",
                table: "Parcel",
                column: "Administrationid");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_LandUseId",
                table: "Parcel",
                column: "LandUseId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_OwnerId",
                table: "Parcel",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_OwnershipRights",
                table: "Parcel",
                column: "OwnershipRights");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_RegistrationId",
                table: "Parcel",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_Responsibilities",
                table: "Parcel",
                column: "Responsibilities");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_Restrictions",
                table: "Parcel",
                column: "Restrictions");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_SpatialUnitId",
                table: "Parcel",
                column: "SpatialUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_TenureId",
                table: "Parcel",
                column: "TenureId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_ValuationId",
                table: "Parcel",
                column: "ValuationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_rateid",
                table: "Payments",
                column: "rateid");

            migrationBuilder.CreateIndex(
                name: "IX_Person_OwnerId",
                table: "Person",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroupMembership_PersonId",
                table: "PersonGroupMembership",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_chrageId",
                table: "Restriction",
                column: "chrageId");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_morgageid",
                table: "Restriction",
                column: "morgageid");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_ReserveID",
                table: "Restriction",
                column: "ReserveID");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_Statutoryid",
                table: "Restriction",
                column: "Statutoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Service_OPid",
                table: "Service",
                column: "OPid");

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
                name: "IX_SpatialUnit_SurveyClassId",
                table: "SpatialUnit",
                column: "SurveyClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SpatialUnitSetRegistration_SpatialUnitSetId",
                table: "SpatialUnitSetRegistration",
                column: "SpatialUnitSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoundaryBeacon");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Freehold");

            migrationBuilder.DropTable(
                name: "GroupGroupLeadership");

            migrationBuilder.DropTable(
                name: "GroupGroupMembership");

            migrationBuilder.DropTable(
                name: "GroupLeadershipPerson");

            migrationBuilder.DropTable(
                name: "GroupOW");

            migrationBuilder.DropTable(
                name: "InstitutionInstitutionLeadership");

            migrationBuilder.DropTable(
                name: "InstitutionLeadershipPerson");

            migrationBuilder.DropTable(
                name: "Leasehold");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PersonGroupMembership");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "SpatialUnitSetRegistration");

            migrationBuilder.DropTable(
                name: "Beacon");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "GroupLeadership");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropTable(
                name: "InsitutionLeadership");

            migrationBuilder.DropTable(
                name: "GroupMembership");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Parcel");

            migrationBuilder.DropTable(
                name: "Administration");

            migrationBuilder.DropTable(
                name: "BuruParcels");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "LandUse");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "OwnershiRights");

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
                name: "Valution");

            migrationBuilder.DropTable(
                name: "BuildingRegulations");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "Charge");

            migrationBuilder.DropTable(
                name: "Mortgage");

            migrationBuilder.DropTable(
                name: "Reserve");

            migrationBuilder.DropTable(
                name: "StaturtoryRestriction");

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
