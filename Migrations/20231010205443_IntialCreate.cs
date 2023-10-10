using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClsOutDocDeliveryCtrl.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RcmdDeadlineBeforeHandover = table.Column<int>(type: "int", nullable: false),
                    RcmdDeadlineAfterHandover = table.Column<int>(type: "int", nullable: false),
                    ActFirstCTRSubmitDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActFirstCTRSubmitDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstCTRSubmitStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpFirstConsultRspDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActFirstConsultRspDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsultFirstRspCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConsultFirstRspStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActSecondCTRSubmitDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActSecondCTRSubmitDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondCTRSubmitStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpSecondConsultRspDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActSecondConsultRspDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsultSecondRspCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConsultSecondRspStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActThirdCTRSubmitDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActThirdCTRSubmitDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThirdCTRSubmitStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpThirdConsultRspDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActThirdConsultRspDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsultThirdRspCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConsultThirdRspStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActOwnerSubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerSubmitStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerSubmitFormat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StoragePlace = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalRetention = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    TotalDeduction = table.Column<decimal>(type: "decimal(5,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConsultantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContractorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConsultantReviewTimeInDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentProject",
                columns: table => new
                {
                    DocumentsDocumentId = table.Column<int>(type: "int", nullable: false),
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentProject", x => new { x.DocumentsDocumentId, x.ProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_DocumentProject_Documents_DocumentsDocumentId",
                        column: x => x.DocumentsDocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentProject_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentProject_ProjectsProjectId",
                table: "DocumentProject",
                column: "ProjectsProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentProject");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
