using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMSInfrastructure.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "MpesaTransaction",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "MpesaTransaction",
                newName: "Type");
        }
    }
}
