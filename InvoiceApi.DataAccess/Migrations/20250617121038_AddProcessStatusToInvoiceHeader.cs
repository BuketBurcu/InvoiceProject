using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProcessStatusToInvoiceHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ProcessStatus",
                table: "InvoiceHeaders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessStatus",
                table: "InvoiceHeaders");
        }
    }
}
