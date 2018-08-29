using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMSInfrastructure.Migrations.ApplicationDb
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Users",
                table: "AspNetRoles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "df046849-d1e1-4b67-8201-125a226cb1ba", "6b2fb652-9536-435f-be4c-48c3e0fbba60", "ApplicationRole", "Authors", "AUTHORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "61058737-4ee8-4976-bfbc-5e1e25e7f2b0", "a47d8717-1ac0-443e-87df-4fb07e66b5bb", "ApplicationRole", "Editors", "EDITORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "CreatedDate", "Description", "IPAddress", "Users" },
                values: new object[] { "a2f8ad46-23cb-4ca1-bb4e-30df9ed09770", "5d39f1b5-31ac-4724-bad8-fb0a16d185e8", "ApplicationRole", "Administrators", "ADMINISTRATORS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "61058737-4ee8-4976-bfbc-5e1e25e7f2b0", "a47d8717-1ac0-443e-87df-4fb07e66b5bb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a2f8ad46-23cb-4ca1-bb4e-30df9ed09770", "5d39f1b5-31ac-4724-bad8-fb0a16d185e8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "df046849-d1e1-4b67-8201-125a226cb1ba", "6b2fb652-9536-435f-be4c-48c3e0fbba60" });

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<int>(
                name: "Users",
                table: "AspNetRoles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
