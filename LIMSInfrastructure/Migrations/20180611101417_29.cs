using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMSInfrastructure.Migrations
{
    public partial class _29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Parcel_ParcelId1",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ParcelId1",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ParcelId1",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "ParcelId",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ParcelId",
                table: "Payments",
                column: "ParcelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Parcel_ParcelId",
                table: "Payments",
                column: "ParcelId",
                principalTable: "Parcel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Parcel_ParcelId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ParcelId",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "ParcelId",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ParcelId1",
                table: "Payments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ParcelId1",
                table: "Payments",
                column: "ParcelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Parcel_ParcelId1",
                table: "Payments",
                column: "ParcelId1",
                principalTable: "Parcel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
