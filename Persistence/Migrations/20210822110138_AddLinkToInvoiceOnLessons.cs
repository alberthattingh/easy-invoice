using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddLinkToInvoiceOnLessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Lessons",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_InvoiceId",
                table: "Lessons",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Invoices_InvoiceId",
                table: "Lessons",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Invoices_InvoiceId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_InvoiceId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Lessons");
        }
    }
}
