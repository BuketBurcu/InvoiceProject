using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMailStatusToInvoiceHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLine_InvoiceHeader_InvoiceId",
                table: "InvoiceLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceLine",
                table: "InvoiceLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceHeader",
                table: "InvoiceHeader");

            migrationBuilder.RenameTable(
                name: "InvoiceLine",
                newName: "InvoiceLines");

            migrationBuilder.RenameTable(
                name: "InvoiceHeader",
                newName: "InvoiceHeaders");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceLine_InvoiceId",
                table: "InvoiceLines",
                newName: "IX_InvoiceLines_InvoiceId");

            migrationBuilder.AddColumn<bool>(
                name: "MailStatus",
                table: "InvoiceHeaders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceLines",
                table: "InvoiceLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceHeaders",
                table: "InvoiceHeaders",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_InvoiceHeaders_InvoiceId",
                table: "InvoiceLines",
                column: "InvoiceId",
                principalTable: "InvoiceHeaders",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_InvoiceHeaders_InvoiceId",
                table: "InvoiceLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceLines",
                table: "InvoiceLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceHeaders",
                table: "InvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "MailStatus",
                table: "InvoiceHeaders");

            migrationBuilder.RenameTable(
                name: "InvoiceLines",
                newName: "InvoiceLine");

            migrationBuilder.RenameTable(
                name: "InvoiceHeaders",
                newName: "InvoiceHeader");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceLines_InvoiceId",
                table: "InvoiceLine",
                newName: "IX_InvoiceLine_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceLine",
                table: "InvoiceLine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceHeader",
                table: "InvoiceHeader",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLine_InvoiceHeader_InvoiceId",
                table: "InvoiceLine",
                column: "InvoiceId",
                principalTable: "InvoiceHeader",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
