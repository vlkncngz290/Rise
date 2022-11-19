using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportService.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToReportContents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReportContents_ReportId",
                table: "ReportContents",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportContents_Reports_ReportId",
                table: "ReportContents",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportContents_Reports_ReportId",
                table: "ReportContents");

            migrationBuilder.DropIndex(
                name: "IX_ReportContents_ReportId",
                table: "ReportContents");
        }
    }
}
