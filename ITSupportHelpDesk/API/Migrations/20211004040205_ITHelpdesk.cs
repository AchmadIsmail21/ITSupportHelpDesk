using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ITHelpdesk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_StatusCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_StatusCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Users_TB_M_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_M_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Review = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Cases_TB_M_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TB_M_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Cases_TB_M_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "TB_M_Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Cases_TB_M_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_Convertations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TR_Convertations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TR_Convertations_TB_M_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "TB_M_Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_TR_Convertations_TB_M_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    StatusCodeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TR_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TR_Histories_TB_M_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "TB_M_Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_TR_Histories_TB_M_StatusCodes_StatusCodeId",
                        column: x => x.StatusCodeId,
                        principalTable: "TB_M_StatusCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_TR_Histories_TB_M_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_StaffCases",
                columns: table => new
                {
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TR_StaffCases", x => new { x.CaseId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_TB_TR_StaffCases_TB_M_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "TB_M_Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_TR_StaffCases_TB_M_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "TB_M_Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Cases_CategoryId",
                table: "TB_M_Cases",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Cases_PriorityId",
                table: "TB_M_Cases",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Cases_UserId",
                table: "TB_M_Cases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Users_RoleId",
                table: "TB_M_Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Convertations_CaseId",
                table: "TB_TR_Convertations",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Convertations_UserId",
                table: "TB_TR_Convertations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Histories_CaseId",
                table: "TB_TR_Histories",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Histories_StatusCodeId",
                table: "TB_TR_Histories",
                column: "StatusCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Histories_UserId",
                table: "TB_TR_Histories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_StaffCases_StaffId",
                table: "TB_TR_StaffCases",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TR_Convertations");

            migrationBuilder.DropTable(
                name: "TB_TR_Histories");

            migrationBuilder.DropTable(
                name: "TB_TR_StaffCases");

            migrationBuilder.DropTable(
                name: "TB_M_StatusCodes");

            migrationBuilder.DropTable(
                name: "TB_M_Cases");

            migrationBuilder.DropTable(
                name: "TB_M_Staffs");

            migrationBuilder.DropTable(
                name: "TB_M_Categories");

            migrationBuilder.DropTable(
                name: "TB_M_Priorities");

            migrationBuilder.DropTable(
                name: "TB_M_Users");

            migrationBuilder.DropTable(
                name: "TB_M_Roles");
        }
    }
}
