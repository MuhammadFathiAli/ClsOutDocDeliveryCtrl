using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClsOutDocDeliveryCtrl.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerSubmittalDeadLineProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OwnerSubmitalDeadline",
                table: "Documents",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerSubmitalDeadline",
                table: "Documents");
        }
    }
}
