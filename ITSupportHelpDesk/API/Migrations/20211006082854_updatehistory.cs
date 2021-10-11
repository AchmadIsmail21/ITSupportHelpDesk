using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class updatehistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffCaseCaseId",
                table: "TB_TR_StaffCases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffCaseStaffId",
                table: "TB_TR_StaffCases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_StaffCases_StaffCaseCaseId_StaffCaseStaffId",
                table: "TB_TR_StaffCases",
                columns: new[] { "StaffCaseCaseId", "StaffCaseStaffId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TR_StaffCases_TB_TR_StaffCases_StaffCaseCaseId_StaffCaseStaffId",
                table: "TB_TR_StaffCases",
                columns: new[] { "StaffCaseCaseId", "StaffCaseStaffId" },
                principalTable: "TB_TR_StaffCases",
                principalColumns: new[] { "CaseId", "StaffId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TR_StaffCases_TB_TR_StaffCases_StaffCaseCaseId_StaffCaseStaffId",
                table: "TB_TR_StaffCases");

            migrationBuilder.DropIndex(
                name: "IX_TB_TR_StaffCases_StaffCaseCaseId_StaffCaseStaffId",
                table: "TB_TR_StaffCases");

            migrationBuilder.DropColumn(
                name: "StaffCaseCaseId",
                table: "TB_TR_StaffCases");

            migrationBuilder.DropColumn(
                name: "StaffCaseStaffId",
                table: "TB_TR_StaffCases");
        }
    }
}
