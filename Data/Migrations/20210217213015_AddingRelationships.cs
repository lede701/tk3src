using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tk3full.Data.Migrations
{
    public partial class AddingRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HoursPerWeekWorked",
                table: "Timesheet",
                newName: "hoursPerWeekWorked");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Timesheet",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Menu",
                newName: "id");

            migrationBuilder.AddColumn<bool>(
                name: "earlySign",
                table: "Timesheet",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "employeeSignDate",
                table: "Timesheet",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "employeeSignature",
                table: "Timesheet",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "employeeStatus",
                table: "Timesheet",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "encryptKey",
                table: "Timesheet",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "endDate",
                table: "Timesheet",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Timesheet",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "Timesheet",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "middleName",
                table: "Timesheet",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "positionDescription",
                table: "Timesheet",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "startDate",
                table: "Timesheet",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "supervisorSignDate",
                table: "Timesheet",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "supervisorSignature",
                table: "Timesheet",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "workHours",
                table: "Timesheet",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ProjectCode",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectTitle = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectDescription = table.Column<string>(type: "TEXT", nullable: true),
                    commentType = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    createdBy = table.Column<int>(type: "INTEGER", nullable: false),
                    modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modifiedBy = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCode", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TimeDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    projectId = table.Column<int>(type: "INTEGER", nullable: false),
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    hrWorked = table.Column<decimal>(type: "TEXT", nullable: false),
                    timeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProjectCodeid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_TimeDetails_ProjectCode_ProjectCodeid",
                        column: x => x.ProjectCodeid,
                        principalTable: "ProjectCode",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeDetails_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_createdBy",
                table: "Menu",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_modifiedBy",
                table: "Menu",
                column: "modifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TimeDetails_ProjectCodeid",
                table: "TimeDetails",
                column: "ProjectCodeid");

            migrationBuilder.CreateIndex(
                name: "IX_TimeDetails_timesheetId",
                table: "TimeDetails",
                column: "timesheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Users_createdBy",
                table: "Menu",
                column: "createdBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_Users_modifiedBy",
                table: "Menu",
                column: "modifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Users_createdBy",
                table: "Menu");

            migrationBuilder.DropForeignKey(
                name: "FK_Menu_Users_modifiedBy",
                table: "Menu");

            migrationBuilder.DropTable(
                name: "TimeDetails");

            migrationBuilder.DropTable(
                name: "ProjectCode");

            migrationBuilder.DropIndex(
                name: "IX_Menu_createdBy",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_modifiedBy",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "earlySign",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "employeeSignDate",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "employeeSignature",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "employeeStatus",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "encryptKey",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "endDate",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "middleName",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "positionDescription",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "supervisorSignDate",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "supervisorSignature",
                table: "Timesheet");

            migrationBuilder.DropColumn(
                name: "workHours",
                table: "Timesheet");

            migrationBuilder.RenameColumn(
                name: "hoursPerWeekWorked",
                table: "Timesheet",
                newName: "HoursPerWeekWorked");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Timesheet",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Menu",
                newName: "Id");
        }
    }
}
