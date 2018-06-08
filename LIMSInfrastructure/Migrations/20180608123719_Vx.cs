using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMSInfrastructure.Migrations
{
    public partial class Vx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Rates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Payments",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Registration",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rates",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payments",
                newName: "id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "Registration",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "(getdate())");
        }
    }
}
