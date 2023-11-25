using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClsOutDocDeliveryCtrl.Migrations
{
    /// <inheritdoc />
    public partial class PercesionofRetDeds2DigitsOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Retention",
                table: "Documents",
                type: "decimal(4,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Deduction",
                table: "Documents",
                type: "decimal(4,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,4)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Retention",
                table: "Documents",
                type: "decimal(6,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Deduction",
                table: "Documents",
                type: "decimal(6,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldNullable: true);
        }
    }
}
