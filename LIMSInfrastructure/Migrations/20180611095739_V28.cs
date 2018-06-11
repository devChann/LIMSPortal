using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMSInfrastructure.Migrations
{
    public partial class V28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Parcel_To_Rates",
            //    table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_To_Rates",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ParcelId",
                table: "Rates");

            migrationBuilder.RenameColumn(
                name: "rateid",
                table: "Payments",
                newName: "RateId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_rateid",
                table: "Payments",
                newName: "IX_Payments_RateId");

            migrationBuilder.AddColumn<string>(
                name: "ParcelId",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParcelId1",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "Parcel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ParcelId1",
                table: "Payments",
                column: "ParcelId1");

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
                name: "FK_Payments_Parcel_ParcelId1",
                table: "Payments",
                column: "ParcelId1",
                principalTable: "Parcel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Rates_RateId",
                table: "Payments",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcel_Rates_RateId",
                table: "Parcel");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Parcel_ParcelId1",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Rates_RateId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ParcelId1",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Parcel_RateId",
                table: "Parcel");

            migrationBuilder.DropColumn(
                name: "ParcelId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ParcelId1",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "Parcel");

            migrationBuilder.RenameColumn(
                name: "RateId",
                table: "Payments",
                newName: "rateid");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_RateId",
                table: "Payments",
                newName: "IX_Payments_rateid");

            migrationBuilder.AddColumn<int>(
                name: "ParcelId",
                table: "Rates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcel_To_Rates",
                table: "Parcel",
                column: "Id",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_To_Rates",
                table: "Payments",
                column: "rateid",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
