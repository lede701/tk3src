using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tk3full.Data.Migrations
{
    public partial class AddingLeave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveBank",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    displayCode = table.Column<string>(type: "TEXT", nullable: true),
                    bankDescription = table.Column<string>(type: "TEXT", nullable: true),
                    expiresInDays = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveBank", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TimeLunch",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    lunchTime = table.Column<decimal>(type: "TEXT", nullable: false),
                    lunchDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLunch", x => x.id);
                    table.ForeignKey(
                        name: "FK_TimeLunch_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTansactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userId = table.Column<int>(type: "INTEGER", nullable: false),
                    parentId = table.Column<int>(type: "INTEGER", nullable: false),
                    locationId = table.Column<int>(type: "INTEGER", nullable: false),
                    bankId = table.Column<int>(type: "INTEGER", nullable: false),
                    tranType = table.Column<char>(type: "TEXT", nullable: false),
                    tranTime = table.Column<decimal>(type: "TEXT", nullable: false),
                    tranDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    displayDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    employeeSigned = table.Column<bool>(type: "INTEGER", nullable: false),
                    approved = table.Column<bool>(type: "INTEGER", nullable: false),
                    isAccrual = table.Column<bool>(type: "INTEGER", nullable: false),
                    isParent = table.Column<bool>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTansactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_LeaveTansactions_LeaveBank_bankId",
                        column: x => x.bankId,
                        principalTable: "LeaveBank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveTansactions_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTansactions_bankId",
                table: "LeaveTansactions",
                column: "bankId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTansactions_userId",
                table: "LeaveTansactions",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLunch_timesheetId",
                table: "TimeLunch",
                column: "timesheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveTansactions");

            migrationBuilder.DropTable(
                name: "TimeLunch");

            migrationBuilder.DropTable(
                name: "LeaveBank");
        }
    }
}
