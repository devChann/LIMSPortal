using Microsoft.EntityFrameworkCore.Migrations;

namespace LIMSInfrastructure.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_MpesaTransaction_MyPropertyId",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "MyPropertyId",
                table: "Payment",
                newName: "MpesaTransactionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payment",
                newName: "PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_MyPropertyId",
                table: "Payment",
                newName: "IX_Payment_MpesaTransactionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Invoice",
                newName: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_MpesaTransaction_MpesaTransactionId",
                table: "Payment",
                column: "MpesaTransactionId",
                principalTable: "MpesaTransaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_MpesaTransaction_MpesaTransactionId",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MpesaTransactionId",
                table: "Payment",
                newName: "MyPropertyId");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Payment",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_MpesaTransactionId",
                table: "Payment",
                newName: "IX_Payment_MyPropertyId");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Invoice",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_MpesaTransaction_MyPropertyId",
                table: "Payment",
                column: "MyPropertyId",
                principalTable: "MpesaTransaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
