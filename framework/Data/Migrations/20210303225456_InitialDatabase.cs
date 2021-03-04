using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Framework.Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    departmentCode = table.Column<string>(type: "TEXT", nullable: true),
                    deptParams = table.Column<string>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    locationId = table.Column<int>(type: "INTEGER", nullable: false),
                    holidayDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    holidayDescription = table.Column<string>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveAccrual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    earnedHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    startYear = table.Column<decimal>(type: "TEXT", nullable: false),
                    endYear = table.Column<decimal>(type: "TEXT", nullable: false),
                    maxHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    rateGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    startDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveAccrual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    displayCode = table.Column<string>(type: "TEXT", nullable: true),
                    bankDescription = table.Column<string>(type: "TEXT", nullable: true),
                    expiresInDays = table.Column<int>(type: "INTEGER", nullable: false),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveBank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    parentId = table.Column<int>(type: "INTEGER", nullable: true),
                    locationCity = table.Column<string>(type: "TEXT", nullable: true),
                    locationState = table.Column<string>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    parentId = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    route = table.Column<string>(type: "TEXT", nullable: true),
                    alias = table.Column<string>(type: "TEXT", nullable: true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    published = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ordering = table.Column<int>(type: "INTEGER", nullable: false),
                    checked_out = table.Column<int>(type: "INTEGER", nullable: false),
                    checked_out_time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    isHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    menuParams = table.Column<string>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectTitle = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectDescription = table.Column<string>(type: "TEXT", nullable: true),
                    commentType = table.Column<int>(type: "INTEGER", nullable: false),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    forignId = table.Column<int>(type: "INTEGER", nullable: false),
                    userName = table.Column<string>(type: "TEXT", nullable: true),
                    passwordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    hashKey = table.Column<byte[]>(type: "BLOB", nullable: true),
                    firstName = table.Column<string>(type: "TEXT", nullable: true),
                    middleName = table.Column<string>(type: "TEXT", nullable: true),
                    lastName = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    locationId = table.Column<int>(type: "INTEGER", nullable: true),
                    departmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    workScheduleId = table.Column<int>(type: "INTEGER", nullable: true),
                    startDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    teminationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    accuralDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    hoursPerDay = table.Column<decimal>(type: "TEXT", nullable: false),
                    hoursPerWeek = table.Column<decimal>(type: "TEXT", nullable: false),
                    hoursPerHoliday = table.Column<decimal>(type: "TEXT", nullable: false),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsEmployees",
                columns: table => new
                {
                    DepartmentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmpoyeesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsEmployees", x => new { x.DepartmentsId, x.EmpoyeesId });
                    table.ForeignKey(
                        name: "FK_DepartmentsEmployees_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsEmployees_Users_EmpoyeesId",
                        column: x => x.EmpoyeesId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTansactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    employeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    parentId = table.Column<int>(type: "INTEGER", nullable: false),
                    locationId = table.Column<int>(type: "INTEGER", nullable: false),
                    bankId = table.Column<int>(type: "INTEGER", nullable: false),
                    tranType = table.Column<char>(type: "TEXT", nullable: false),
                    tranTime = table.Column<decimal>(type: "TEXT", nullable: false),
                    tranDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    displayDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    employeeSigned = table.Column<bool>(type: "INTEGER", nullable: false),
                    approved = table.Column<bool>(type: "INTEGER", nullable: false),
                    isAccrual = table.Column<bool>(type: "INTEGER", nullable: false),
                    isParent = table.Column<bool>(type: "INTEGER", nullable: false),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTansactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveTansactions_LeaveBank_bankId",
                        column: x => x.bankId,
                        principalTable: "LeaveBank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveTansactions_Users_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    employeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    lastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dateExpire = table.Column<DateTime>(type: "TEXT", nullable: false),
                    signatureHash = table.Column<string>(type: "TEXT", nullable: true),
                    isLocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Signatures_Users_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timesheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    employeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    earlySign = table.Column<bool>(type: "INTEGER", nullable: false),
                    positionDescription = table.Column<string>(type: "TEXT", nullable: true),
                    firstName = table.Column<string>(type: "TEXT", nullable: true),
                    middleName = table.Column<string>(type: "TEXT", nullable: true),
                    lastname = table.Column<string>(type: "TEXT", nullable: true),
                    hoursPerDay = table.Column<decimal>(type: "TEXT", nullable: false),
                    hoursPerWeek = table.Column<decimal>(type: "TEXT", nullable: false),
                    employeeStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    startDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    employeeSignDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    supervisorSignDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    encryptKey = table.Column<string>(type: "TEXT", nullable: true),
                    employeeSignature = table.Column<string>(type: "TEXT", nullable: true),
                    supervisorSignature = table.Column<string>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheet_Users_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolidayEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    holidayId = table.Column<int>(type: "INTEGER", nullable: false),
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    holidayHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    comment = table.Column<string>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolidayEmployee_Holidays_holidayId",
                        column: x => x.holidayId,
                        principalTable: "Holidays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HolidayEmployee_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    projectId = table.Column<int>(type: "INTEGER", nullable: false),
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    hrWorked = table.Column<decimal>(type: "TEXT", nullable: false),
                    timeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeDetails_ProjectCode_projectId",
                        column: x => x.projectId,
                        principalTable: "ProjectCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeDetails_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeLunch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    lunchTime = table.Column<decimal>(type: "TEXT", nullable: false),
                    lunchDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLunch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeLunch_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimesheetExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    supervisorId = table.Column<int>(type: "INTEGER", nullable: false),
                    approved = table.Column<bool>(type: "INTEGER", nullable: false),
                    weekTime = table.Column<decimal>(type: "TEXT", nullable: false),
                    weekNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    weekStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    weekEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    employeeComment = table.Column<string>(type: "TEXT", nullable: true),
                    comment = table.Column<string>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetExceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimesheetExceptions_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimesheetExceptions_Users_supervisorId",
                        column: x => x.supervisorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimesheetProjects",
                columns: table => new
                {
                    TimesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectCodeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetProjects", x => new { x.TimesheetId, x.ProjectCodeId });
                    table.ForeignKey(
                        name: "FK_TimesheetProjects_ProjectCode_ProjectCodeId",
                        column: x => x.ProjectCodeId,
                        principalTable: "ProjectCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimesheetProjects_Timesheet_TimesheetId",
                        column: x => x.TimesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeDetailsComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    timeDetailsId = table.Column<int>(type: "INTEGER", nullable: false),
                    timesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedById = table.Column<int>(type: "INTEGER", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedById = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeDetailsComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeDetailsComments_TimeDetails_timeDetailsId",
                        column: x => x.timeDetailsId,
                        principalTable: "TimeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeDetailsComments_Timesheet_timesheetId",
                        column: x => x.timesheetId,
                        principalTable: "Timesheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsEmployees_EmpoyeesId",
                table: "DepartmentsEmployees",
                column: "EmpoyeesId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayEmployee_holidayId",
                table: "HolidayEmployee",
                column: "holidayId");

            migrationBuilder.CreateIndex(
                name: "IX_HolidayEmployee_timesheetId",
                table: "HolidayEmployee",
                column: "timesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTansactions_bankId",
                table: "LeaveTansactions",
                column: "bankId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTansactions_employeeId",
                table: "LeaveTansactions",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_employeeId",
                table: "Signatures",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeDetails_projectId",
                table: "TimeDetails",
                column: "projectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeDetails_timesheetId",
                table: "TimeDetails",
                column: "timesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeDetailsComments_timeDetailsId",
                table: "TimeDetailsComments",
                column: "timeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeDetailsComments_timesheetId",
                table: "TimeDetailsComments",
                column: "timesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLunch_timesheetId",
                table: "TimeLunch",
                column: "timesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_employeeId",
                table: "Timesheet",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetExceptions_supervisorId",
                table: "TimesheetExceptions",
                column: "supervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetExceptions_timesheetId",
                table: "TimesheetExceptions",
                column: "timesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetProjects_ProjectCodeId",
                table: "TimesheetProjects",
                column: "ProjectCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentsEmployees");

            migrationBuilder.DropTable(
                name: "HolidayEmployee");

            migrationBuilder.DropTable(
                name: "LeaveAccrual");

            migrationBuilder.DropTable(
                name: "LeaveTansactions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "TimeDetailsComments");

            migrationBuilder.DropTable(
                name: "TimeLunch");

            migrationBuilder.DropTable(
                name: "TimesheetExceptions");

            migrationBuilder.DropTable(
                name: "TimesheetProjects");

            migrationBuilder.DropTable(
                name: "WorkSchedule");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "LeaveBank");

            migrationBuilder.DropTable(
                name: "TimeDetails");

            migrationBuilder.DropTable(
                name: "ProjectCode");

            migrationBuilder.DropTable(
                name: "Timesheet");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
