using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClsOutDocDeliveryCtrl.Migrations
{
    /// <inheritdoc />
    public partial class modifyRetDedsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalRetention",
                table: "Documents",
                newName: "Retention");

            migrationBuilder.RenameColumn(
                name: "TotalDeduction",
                table: "Documents",
                newName: "Deduction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Retention",
                table: "Documents",
                newName: "TotalRetention");

            migrationBuilder.RenameColumn(
                name: "Deduction",
                table: "Documents",
                newName: "TotalDeduction");
        }
    }
}
