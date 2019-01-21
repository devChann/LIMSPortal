using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMSInfrastructure.Migrations.LIMSCoreDb
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_GroupGroupMembership_GroupId",
                table: "GroupGroupMembership");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39c53c55-b17e-4766-826e-f8518ea4e4ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b4f5751-875a-4978-a3c0-c3b4499fa2e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf4ce666-2410-4293-9672-9af2e55a57c6");

            migrationBuilder.DropColumn(
                name: "PersonInstitutionLeadershipId",
                table: "PersonInstitutionLeadership");

            migrationBuilder.DropColumn(
                name: "PersonGroupMembershipId",
                table: "PersonGroupMembership");

            migrationBuilder.DropColumn(
                name: "PersonGroupLeadershipId",
                table: "PersonGroupLeadership");

            migrationBuilder.DropColumn(
                name: "InstitutionInstitutionLeadershipId",
                table: "InstitutionInstitutionLeadership");

            migrationBuilder.DropColumn(
                name: "GroupGroupMembershipId",
                table: "GroupGroupMembership");

            migrationBuilder.DropColumn(
                name: "GroupGroupLeadershipId",
                table: "GroupGroupLeadership");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonGroupMembership",
                table: "PersonGroupMembership",
                columns: new[] { "GroupMembershipId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupGroupMembership",
                table: "GroupGroupMembership",
                columns: new[] { "GroupId", "GroupMembershipId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "5d3d2a69-83e5-400b-9115-63a9ee674a4a", "bf52a184-7240-4082-bf8f-e9f311b00aed", "ApplicationRole", "Authors", "AUTHORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "040ea055-50f0-4f64-9d71-1f225d87060d", "6332f62b-7353-4830-9781-25601110c355", "ApplicationRole", "Editors", "EDITORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "bd2a2fd2-099e-4f43-811e-b4f2149922cb", "364d81a5-47d2-4b69-9519-6cb09ead3eb5", "ApplicationRole", "Administrators", "ADMINISTRATORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonGroupMembership",
                table: "PersonGroupMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupGroupMembership",
                table: "GroupGroupMembership");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "040ea055-50f0-4f64-9d71-1f225d87060d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d3d2a69-83e5-400b-9115-63a9ee674a4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2a2fd2-099e-4f43-811e-b4f2149922cb");

            migrationBuilder.AddColumn<int>(
                name: "PersonInstitutionLeadershipId",
                table: "PersonInstitutionLeadership",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonGroupMembershipId",
                table: "PersonGroupMembership",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "PersonGroupLeadershipId",
                table: "PersonGroupLeadership",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "39c53c55-b17e-4766-826e-f8518ea4e4ff", "3a2fc33d-b4ea-46cb-a253-027c78bbcc16", "ApplicationRole", "Authors", "AUTHORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "cf4ce666-2410-4293-9672-9af2e55a57c6", "f1c75dff-1d2e-450d-9449-3a0fdb37173b", "ApplicationRole", "Editors", "EDITORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "8b4f5751-875a-4978-a3c0-c3b4499fa2e3", "dbb17230-0b45-4999-916c-84629c4437ca", "ApplicationRole", "Administrators", "ADMINISTRATORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_PersonGroupMembership_GroupMembershipId",
                table: "PersonGroupMembership",
                column: "GroupMembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGroupMembership_GroupId",
                table: "GroupGroupMembership",
                column: "GroupId");
        }
    }
}
