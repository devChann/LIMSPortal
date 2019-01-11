using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMSInfrastructure.Migrations.LIMSCoreDb
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LandUse_BuildingRegulations_BuildingRegulationsId",
                table: "LandUse");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Administration",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Owners",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_OwnershiRights",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Rates",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Responsibility",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Restriction",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Valution_ValuationId",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Parcel",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Restriction_Charge",
                table: "Restriction");

            migrationBuilder.DropForeignKey(
                name: "FK_Restriction_StaturtoryRestriction",
                table: "Restriction");

            migrationBuilder.DropForeignKey(
                name: "FK_SpatialUnit_Survey_SurveyClassId",
                table: "SpatialUnit");

            migrationBuilder.DropTable(
                name: "BuildingRegulations");

            migrationBuilder.DropTable(
                name: "GroupLeadershipPerson");

            migrationBuilder.DropTable(
                name: "GroupOW");

            migrationBuilder.DropTable(
                name: "InstitutionLeadershipPerson");

            migrationBuilder.DropTable(
                name: "OwnershiRights");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "StaturtoryRestriction");

            migrationBuilder.DropTable(
                name: "Valution");

            migrationBuilder.DropIndex(
                name: "IX_Restriction_chrageId",
                table: "Restriction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonGroupMembership",
                table: "PersonGroupMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupGroupMembership",
                table: "GroupGroupMembership");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b37b32d-26a9-4aa5-a869-7de6db6f4e23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3acc021c-6073-45ee-a32a-5b368e777cec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6252fb0-3b13-42fb-8d4a-d3d35a21d631");

            migrationBuilder.DropColumn(
                name: "RegulationId",
                table: "Zone");

            migrationBuilder.DropColumn(
                name: "chrageId",
                table: "Restriction");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "ParcelId",
                table: "MapIndex");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Zone",
                newName: "ZoneId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tenure",
                newName: "TenureId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Survey",
                newName: "SurveyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SpatialUnitSet",
                newName: "SpatialUnitSetId");

            migrationBuilder.RenameColumn(
                name: "SurveyClassId",
                table: "SpatialUnit",
                newName: "SurveyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SpatialUnit",
                newName: "SpatialUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_SpatialUnit_SurveyClassId",
                table: "SpatialUnit",
                newName: "IX_SpatialUnit_SurveyId");

            migrationBuilder.RenameColumn(
                name: "OPid",
                table: "Service",
                newName: "OperationId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Service",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Service",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_OPid",
                table: "Service",
                newName: "IX_Service_OperationId");

            migrationBuilder.RenameColumn(
                name: "ReserveID",
                table: "Restriction",
                newName: "ReserveId");

            migrationBuilder.RenameColumn(
                name: "Statutoryid",
                table: "Restriction",
                newName: "StatutoryRestrictionId");

            migrationBuilder.RenameColumn(
                name: "morgageid",
                table: "Restriction",
                newName: "MortgageId");

            migrationBuilder.RenameColumn(
                name: "landUseId",
                table: "Restriction",
                newName: "ChargeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Restriction",
                newName: "RestrictionId");

            migrationBuilder.RenameIndex(
                name: "IX_Restriction_ReserveID",
                table: "Restriction",
                newName: "IX_Restriction_ReserveId");

            migrationBuilder.RenameIndex(
                name: "IX_Restriction_Statutoryid",
                table: "Restriction",
                newName: "IX_Restriction_StatutoryRestrictionId");

            migrationBuilder.RenameIndex(
                name: "IX_Restriction_morgageid",
                table: "Restriction",
                newName: "IX_Restriction_MortgageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Responsibility",
                newName: "ResponsibilityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reserve",
                newName: "ReserveId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Registration",
                newName: "RegistrationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payments",
                newName: "PaymentsId");

            migrationBuilder.RenameColumn(
                name: "Administrationid",
                table: "Parcel",
                newName: "AdministrationId");

            migrationBuilder.RenameColumn(
                name: "Restrictions",
                table: "Parcel",
                newName: "RestrictionId");

            migrationBuilder.RenameColumn(
                name: "Responsibilities",
                table: "Parcel",
                newName: "ResponsibilityId");

            migrationBuilder.RenameColumn(
                name: "OwnershipRights",
                table: "Parcel",
                newName: "OwnershipRightId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Parcel",
                newName: "ParcelId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcel_Administrationid",
                table: "Parcel",
                newName: "IX_Parcel_AdministrationId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcel_Restrictions",
                table: "Parcel",
                newName: "IX_Parcel_RestrictionId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcel_Responsibilities",
                table: "Parcel",
                newName: "IX_Parcel_ResponsibilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcel_OwnershipRights",
                table: "Parcel",
                newName: "IX_Parcel_OwnershipRightId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Owner",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "Parcelid",
                table: "Operation",
                newName: "ParcelId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Operation",
                newName: "OperationName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Operation",
                newName: "OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_Operation_Parcelid",
                table: "Operation",
                newName: "IX_Operation_ParcelId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mortgage",
                newName: "MortgageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MapIndex",
                newName: "MapIndexId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Leasehold",
                newName: "LeaseholdId");

            migrationBuilder.RenameColumn(
                name: "BuildingRegulationsId",
                table: "LandUse",
                newName: "BuildingRegulationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LandUse",
                newName: "LandUseId");

            migrationBuilder.RenameIndex(
                name: "IX_LandUse_BuildingRegulationsId",
                table: "LandUse",
                newName: "IX_LandUse_BuildingRegulationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Institution",
                newName: "InstitutionId");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "GroupLeadership",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GroupLeadership",
                newName: "GroupLeadershipId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Freehold",
                newName: "FreeholdId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Charge",
                newName: "ChargeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Building",
                newName: "BuildingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Boundary",
                newName: "BoundaryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Beacon",
                newName: "BeaconId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Apartment",
                newName: "ApartmentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Administration",
                newName: "AdministrationId");

            migrationBuilder.AddColumn<int>(
                name: "PersonGroupMembershipId",
                table: "PersonGroupMembership",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiptNo",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "ModeOfPayment",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstitutionInstitutionLeadershipId",
                table: "InstitutionInstitutionLeadership",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupGroupMembershipId",
                table: "GroupGroupMembership",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "GroupGroupLeadershipId",
                table: "GroupGroupLeadership",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonGroupMembership",
                table: "PersonGroupMembership",
                column: "PersonGroupMembershipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupGroupMembership",
                table: "GroupGroupMembership",
                column: "GroupGroupMembershipId");

            migrationBuilder.CreateTable(
                name: "BuildingRegulation",
                columns: table => new
                {
                    BuildingRegulationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GCR = table.Column<double>(nullable: false),
                    PCR = table.Column<double>(nullable: false),
                    PlotFrontage = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingRegulation", x => x.BuildingRegulationId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    County = table.Column<string>(nullable: true),
                    GroupType = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false)
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
                name: "OwnershipRight",
                columns: table => new
                {
                    OwnershipRightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RightType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipRight", x => x.OwnershipRightId);
                });

            migrationBuilder.CreateTable(
                name: "PersonGroupLeadership",
                columns: table => new
                {
                    GroupLeadershipId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    PersonGroupLeadershipId = table.Column<int>(nullable: false)
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
                name: "PersonInstitutionLeadership",
                columns: table => new
                {
                    InstitutionLeadershipId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    PersonInstitutionLeadershipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInstitutionLeadership", x => new { x.InstitutionLeadershipId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_PersonInstitutionLeadership_InsitutionLeadership_InstitutionLeadershipId",
                        column: x => x.InstitutionLeadershipId,
                        principalTable: "InsitutionLeadership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInstitutionLeadership_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    RateId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.RateId);
                });

            migrationBuilder.CreateTable(
                name: "StatutoryRestriction",
                columns: table => new
                {
                    StatutoryRestrictionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NatureOfRestriction = table.Column<string>(nullable: true),
                    RestrictingAuthority = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatutoryRestriction", x => x.StatutoryRestrictionId);
                });

            migrationBuilder.CreateTable(
                name: "Valuation",
                columns: table => new
                {
                    ValuationId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Valuation", x => x.ValuationId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "6d378dc9-28c1-4cb5-99f9-8904796fa2f5", "5e19c553-e3e3-4c8e-b106-86959c5951c6", "ApplicationRole", "Authors", "AUTHORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "d39fddd8-ee8d-4ede-bd9e-fb044c251439", "15b1a7f8-61cc-440b-a7ae-8636d44f25fd", "ApplicationRole", "Editors", "EDITORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "5d8c4f8e-2082-4476-b715-3e08efd21586", "f0c54831-160c-4fdd-aa32-d8af5bd5734e", "ApplicationRole", "Administrators", "ADMINISTRATORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_ChargeId",
                table: "Restriction",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroupMembership_GroupMembershipId",
                table: "PersonGroupMembership",
                column: "GroupMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGroupMembership_GroupMembershipId",
                table: "GroupGroupMembership",
                column: "GroupMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_OwnerId",
                table: "Group",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroupLeadership_PersonId",
                table: "PersonGroupLeadership",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInstitutionLeadership_PersonId",
                table: "PersonInstitutionLeadership",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupGroupLeadership_Group_GroupId",
                table: "GroupGroupLeadership",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupGroupMembership_Group_GroupId",
                table: "GroupGroupMembership",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LandUse_BuildingRegulation_BuildingRegulationId",
                table: "LandUse",
                column: "BuildingRegulationId",
                principalTable: "BuildingRegulation",
                principalColumn: "BuildingRegulationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Administration_AdministrationId",
                table: "Parcel",
                column: "AdministrationId",
                principalTable: "Administration",
                principalColumn: "AdministrationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Owner_OwnerId",
                table: "Parcel",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_OwnershipRight_OwnershipRightId",
                table: "Parcel",
                column: "OwnershipRightId",
                principalTable: "OwnershipRight",
                principalColumn: "OwnershipRightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Rate_RateId",
                table: "Parcel",
                column: "RateId",
                principalTable: "Rate",
                principalColumn: "RateId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Responsibility_ResponsibilityId",
                table: "Parcel",
                column: "ResponsibilityId",
                principalTable: "Responsibility",
                principalColumn: "ResponsibilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Restriction_RestrictionId",
                table: "Parcel",
                column: "RestrictionId",
                principalTable: "Restriction",
                principalColumn: "RestrictionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Valuation_ValuationId",
                table: "Parcel",
                column: "ValuationId",
                principalTable: "Valuation",
                principalColumn: "ValuationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Parcel_ParcelId",
                table: "Payments",
                column: "ParcelId",
                principalTable: "Parcel",
                principalColumn: "ParcelId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restriction_Charge",
                table: "Restriction",
                column: "ChargeId",
                principalTable: "Charge",
                principalColumn: "ChargeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restriction_StatutoryRestriction",
                table: "Restriction",
                column: "StatutoryRestrictionId",
                principalTable: "StatutoryRestriction",
                principalColumn: "StatutoryRestrictionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpatialUnit_Survey_SurveyId",
                table: "SpatialUnit",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "SurveyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupGroupLeadership_Group_GroupId",
                table: "GroupGroupLeadership");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupGroupMembership_Group_GroupId",
                table: "GroupGroupMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_LandUse_BuildingRegulation_BuildingRegulationId",
                table: "LandUse");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Administration_AdministrationId",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Owner_OwnerId",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_OwnershipRight_OwnershipRightId",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Rate_RateId",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Responsibility_ResponsibilityId",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Restriction_RestrictionId",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Valuation_ValuationId",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Parcel_ParcelId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Restriction_Charge",
                table: "Restriction");

            migrationBuilder.DropForeignKey(
                name: "FK_Restriction_StatutoryRestriction",
                table: "Restriction");

            migrationBuilder.DropForeignKey(
                name: "FK_SpatialUnit_Survey_SurveyId",
                table: "SpatialUnit");

            migrationBuilder.DropTable(
                name: "BuildingRegulation");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "OwnershipRight");

            migrationBuilder.DropTable(
                name: "PersonGroupLeadership");

            migrationBuilder.DropTable(
                name: "PersonInstitutionLeadership");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "StatutoryRestriction");

            migrationBuilder.DropTable(
                name: "Valuation");

            migrationBuilder.DropIndex(
                name: "IX_Restriction_ChargeId",
                table: "Restriction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonGroupMembership",
                table: "PersonGroupMembership");

            migrationBuilder.DropIndex(
                name: "IX_PersonGroupMembership_GroupMembershipId",
                table: "PersonGroupMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupGroupMembership",
                table: "GroupGroupMembership");

            migrationBuilder.DropIndex(
                name: "IX_GroupGroupMembership_GroupMembershipId",
                table: "GroupGroupMembership");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d8c4f8e-2082-4476-b715-3e08efd21586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d378dc9-28c1-4cb5-99f9-8904796fa2f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d39fddd8-ee8d-4ede-bd9e-fb044c251439");

            migrationBuilder.DropColumn(
                name: "PersonGroupMembershipId",
                table: "PersonGroupMembership");

            migrationBuilder.DropColumn(
                name: "InstitutionInstitutionLeadershipId",
                table: "InstitutionInstitutionLeadership");

            migrationBuilder.DropColumn(
                name: "GroupGroupMembershipId",
                table: "GroupGroupMembership");

            migrationBuilder.DropColumn(
                name: "GroupGroupLeadershipId",
                table: "GroupGroupLeadership");

            migrationBuilder.RenameColumn(
                name: "ZoneId",
                table: "Zone",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TenureId",
                table: "Tenure",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "Survey",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SpatialUnitSetId",
                table: "SpatialUnitSet",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "SpatialUnit",
                newName: "SurveyClassId");

            migrationBuilder.RenameColumn(
                name: "SpatialUnitId",
                table: "SpatialUnit",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_SpatialUnit_SurveyId",
                table: "SpatialUnit",
                newName: "IX_SpatialUnit_SurveyClassId");

            migrationBuilder.RenameColumn(
                name: "OperationId",
                table: "Service",
                newName: "OPid");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Service",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Service",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Service_OperationId",
                table: "Service",
                newName: "IX_Service_OPid");

            migrationBuilder.RenameColumn(
                name: "ReserveId",
                table: "Restriction",
                newName: "ReserveID");

            migrationBuilder.RenameColumn(
                name: "StatutoryRestrictionId",
                table: "Restriction",
                newName: "Statutoryid");

            migrationBuilder.RenameColumn(
                name: "MortgageId",
                table: "Restriction",
                newName: "morgageid");

            migrationBuilder.RenameColumn(
                name: "ChargeId",
                table: "Restriction",
                newName: "landUseId");

            migrationBuilder.RenameColumn(
                name: "RestrictionId",
                table: "Restriction",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Restriction_ReserveId",
                table: "Restriction",
                newName: "IX_Restriction_ReserveID");

            migrationBuilder.RenameIndex(
                name: "IX_Restriction_StatutoryRestrictionId",
                table: "Restriction",
                newName: "IX_Restriction_Statutoryid");

            migrationBuilder.RenameIndex(
                name: "IX_Restriction_MortgageId",
                table: "Restriction",
                newName: "IX_Restriction_morgageid");

            migrationBuilder.RenameColumn(
                name: "ResponsibilityId",
                table: "Responsibility",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ReserveId",
                table: "Reserve",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RegistrationId",
                table: "Registration",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Person",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PaymentsId",
                table: "Payments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "AdministrationId",
                table: "Parcel",
                newName: "Administrationid");

            migrationBuilder.RenameColumn(
                name: "RestrictionId",
                table: "Parcel",
                newName: "Restrictions");

            migrationBuilder.RenameColumn(
                name: "ResponsibilityId",
                table: "Parcel",
                newName: "Responsibilities");

            migrationBuilder.RenameColumn(
                name: "OwnershipRightId",
                table: "Parcel",
                newName: "OwnershipRights");

            migrationBuilder.RenameColumn(
                name: "ParcelId",
                table: "Parcel",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Parcel_AdministrationId",
                table: "Parcel",
                newName: "IX_Parcel_Administrationid");

            migrationBuilder.RenameIndex(
                name: "IX_Parcel_RestrictionId",
                table: "Parcel",
                newName: "IX_Parcel_Restrictions");

            migrationBuilder.RenameIndex(
                name: "IX_Parcel_ResponsibilityId",
                table: "Parcel",
                newName: "IX_Parcel_Responsibilities");

            migrationBuilder.RenameIndex(
                name: "IX_Parcel_OwnershipRightId",
                table: "Parcel",
                newName: "IX_Parcel_OwnershipRights");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Owner",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ParcelId",
                table: "Operation",
                newName: "Parcelid");

            migrationBuilder.RenameColumn(
                name: "OperationName",
                table: "Operation",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OperationId",
                table: "Operation",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Operation_ParcelId",
                table: "Operation",
                newName: "IX_Operation_Parcelid");

            migrationBuilder.RenameColumn(
                name: "MortgageId",
                table: "Mortgage",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MapIndexId",
                table: "MapIndex",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LeaseholdId",
                table: "Leasehold",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BuildingRegulationId",
                table: "LandUse",
                newName: "BuildingRegulationsId");

            migrationBuilder.RenameColumn(
                name: "LandUseId",
                table: "LandUse",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_LandUse_BuildingRegulationId",
                table: "LandUse",
                newName: "IX_LandUse_BuildingRegulationsId");

            migrationBuilder.RenameColumn(
                name: "InstitutionId",
                table: "Institution",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "GroupLeadership",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "GroupLeadershipId",
                table: "GroupLeadership",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FreeholdId",
                table: "Freehold",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ChargeId",
                table: "Charge",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "Building",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BoundaryId",
                table: "Boundary",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BeaconId",
                table: "Beacon",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "Apartment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AdministrationId",
                table: "Administration",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "RegulationId",
                table: "Zone",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "chrageId",
                table: "Restriction",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiptNo",
                table: "Payments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Payments",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModeOfPayment",
                table: "Payments",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Payments",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingId",
                table: "Mortgage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParcelId",
                table: "MapIndex",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonGroupMembership",
                table: "PersonGroupMembership",
                columns: new[] { "GroupMembershipId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupGroupMembership",
                table: "GroupGroupMembership",
                columns: new[] { "GroupMembershipId", "GroupId" });

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "2b37b32d-26a9-4aa5-a869-7de6db6f4e23", "f9223225-3c28-42cf-812c-da5f0caffdc4", "ApplicationRole", "Authors", "AUTHORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "3acc021c-6073-45ee-a32a-5b368e777cec", "29374409-38c9-4ba6-ba55-ef8061ae363b", "ApplicationRole", "Editors", "EDITORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "c6252fb0-3b13-42fb-8d4a-d3d35a21d631", "3db2c288-7dca-4c06-b02c-dd5e75b7686d", "ApplicationRole", "Administrators", "ADMINISTRATORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_chrageId",
                table: "Restriction",
                column: "chrageId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLeadershipPerson_PersonId",
                table: "GroupLeadershipPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOW_OwnerId",
                table: "GroupOW",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionLeadershipPerson_PersonId",
                table: "InstitutionLeadershipPerson",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_LandUse_BuildingRegulations_BuildingRegulationsId",
                table: "LandUse",
                column: "BuildingRegulationsId",
                principalTable: "BuildingRegulations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Administration",
                table: "Parcel",
                column: "Administrationid",
                principalTable: "Administration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Owners",
                table: "Parcel",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_OwnershiRights",
                table: "Parcel",
                column: "OwnershipRights",
                principalTable: "OwnershiRights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Rates",
                table: "Parcel",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Responsibility",
                table: "Parcel",
                column: "Responsibilities",
                principalTable: "Responsibility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Restriction",
                table: "Parcel",
                column: "Restrictions",
                principalTable: "Restriction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Valution_ValuationId",
                table: "Parcel",
                column: "ValuationId",
                principalTable: "Valution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Parcel",
                table: "Payments",
                column: "ParcelId",
                principalTable: "Parcel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restriction_Charge",
                table: "Restriction",
                column: "chrageId",
                principalTable: "Charge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restriction_StaturtoryRestriction",
                table: "Restriction",
                column: "Statutoryid",
                principalTable: "StaturtoryRestriction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpatialUnit_Survey_SurveyClassId",
                table: "SpatialUnit",
                column: "SurveyClassId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
