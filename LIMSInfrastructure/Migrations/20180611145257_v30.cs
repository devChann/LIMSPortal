using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMSInfrastructure.Migrations
{
    public partial class v30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Parcel_Rates_RateId",
            //    table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Parcel_ParcelId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Rates_RateId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ParcelId",
                table: "Payments");

            //migrationBuilder.DropIndex(
            //    name: "IX_Parcel_RateId",
            //    table: "Parcel");

            migrationBuilder.DropColumn(
                name: "ParcelId",
                table: "Payments");

            //migrationBuilder.DropColumn(
            //    name: "RateId",
            //    table: "Parcel");

            migrationBuilder.AddColumn<int>(
                name: "ParcelId",
                table: "Rates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_ParcelId",
                table: "Rates",
                column: "ParcelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_To_Rates",
                table: "Payments",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Parcel_ParcelId",
                table: "Rates",
                column: "ParcelId",
                principalTable: "Parcel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_To_Rates",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Parcel_ParcelId",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_ParcelId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "ParcelId",
                table: "Rates");

            migrationBuilder.AddColumn<int>(
                name: "ParcelId",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "Parcel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ParcelId",
                table: "Payments",
                column: "ParcelId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcel_RateId",
                table: "Parcel",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_Rates_RateId",
                table: "Parcel",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Parcel_ParcelId",
                table: "Payments",
                column: "ParcelId",
                principalTable: "Parcel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Rates_RateId",
                table: "Payments",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
