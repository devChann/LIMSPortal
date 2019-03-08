using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMSInfrastructure.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MpesaTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    CheckoutRequestID = table.Column<string>(nullable: true),
                    MerchantRequestId = table.Column<string>(nullable: true),
                    ReceiptNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpesaTransaction", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MpesaTransaction");
        }
    }
}
