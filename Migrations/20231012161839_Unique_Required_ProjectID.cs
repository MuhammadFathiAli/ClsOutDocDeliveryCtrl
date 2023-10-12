using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClsOutDocDeliveryCtrl.Migrations
{
    /// <inheritdoc />
    public partial class Unique_Required_ProjectID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                table: "Projects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Name_ProjectId",
                table: "Documents",
                columns: new[] { "Name", "ProjectId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_Name",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Documents_Name_ProjectId",
                table: "Documents");
        }
    }
}
