﻿// <auto-generated />
using System;
using Framework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Framework.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210303225456_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Core.Entities.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("alias")
                        .HasColumnType("TEXT");

                    b.Property<int>("checked_out")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("checked_out_time")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isHome")
                        .HasColumnType("INTEGER");

                    b.Property<string>("menuParams")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("ordering")
                        .HasColumnType("INTEGER");

                    b.Property<int>("parentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("published")
                        .HasColumnType("TEXT");

                    b.Property<string>("route")
                        .HasColumnType("TEXT");

                    b.Property<string>("type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("departmentCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("deptParams")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.DepartmentsEmployees", b =>
                {
                    b.Property<int>("DepartmentsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmpoyeesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DepartmentsId", "EmpoyeesId");

                    b.HasIndex("EmpoyeesId");

                    b.ToTable("DepartmentsEmployees");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.HolidayEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("comment")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("holidayHours")
                        .HasColumnType("TEXT");

                    b.Property<int>("holidayId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("timesheetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("holidayId");

                    b.HasIndex("timesheetId");

                    b.ToTable("HolidayEmployee");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Holidays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("holidayDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("holidayDescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("locationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.LeaveAccural", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("earnedHours")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("endYear")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("maxHours")
                        .HasColumnType("TEXT");

                    b.Property<int>("rateGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("startYear")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LeaveAccrual");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.LeaveBank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("bankDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("displayCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("expiresInDays")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LeaveBank");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.LeaveTransactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("approved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("bankId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("displayDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("employeeId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("employeeSigned")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isAccrual")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isParent")
                        .HasColumnType("INTEGER");

                    b.Property<int>("locationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("parentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("tranDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("tranTime")
                        .HasColumnType("TEXT");

                    b.Property<char>("tranType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("bankId");

                    b.HasIndex("employeeId");

                    b.ToTable("LeaveTansactions");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Locations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<string>("locationCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("locationState")
                        .HasColumnType("TEXT");

                    b.Property<int?>("parentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.ProjectCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectTitle")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("commentType")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProjectCode");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Signatures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dateExpire")
                        .HasColumnType("TEXT");

                    b.Property<int>("employeeId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isLocked")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("lastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("signatureHash")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("employeeId");

                    b.ToTable("Signatures");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimeDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("hrWorked")
                        .HasColumnType("TEXT");

                    b.Property<int>("projectId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("timeDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("timesheetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("projectId");

                    b.HasIndex("timesheetId");

                    b.ToTable("TimeDetails");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimeDetailsComments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<int>("timeDetailsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("timesheetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("timeDetailsId");

                    b.HasIndex("timesheetId");

                    b.ToTable("TimeDetailsComments");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimeLunch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lunchDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("lunchTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("timesheetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("timesheetId");

                    b.ToTable("TimeLunch");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Timesheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("earlySign")
                        .HasColumnType("INTEGER");

                    b.Property<int>("employeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("employeeSignDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("employeeSignature")
                        .HasColumnType("TEXT");

                    b.Property<int>("employeeStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("encryptKey")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("hoursPerDay")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("hoursPerWeek")
                        .HasColumnType("TEXT");

                    b.Property<string>("lastname")
                        .HasColumnType("TEXT");

                    b.Property<string>("middleName")
                        .HasColumnType("TEXT");

                    b.Property<string>("positionDescription")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("supervisorSignDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("supervisorSignature")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("employeeId");

                    b.ToTable("Timesheet");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimesheetExceptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("approved")
                        .HasColumnType("INTEGER");

                    b.Property<string>("comment")
                        .HasColumnType("TEXT");

                    b.Property<string>("employeeComment")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<int>("supervisorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("timesheetId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("weekEnd")
                        .HasColumnType("TEXT");

                    b.Property<int>("weekNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("weekStart")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("weekTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("supervisorId");

                    b.HasIndex("timesheetId");

                    b.ToTable("TimesheetExceptions");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimesheetProjects", b =>
                {
                    b.Property<int>("TimesheetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectCodeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TimesheetId", "ProjectCodeId");

                    b.HasIndex("ProjectCodeId");

                    b.ToTable("TimesheetProjects");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.WorkSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("hoursPerDay")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("hoursPerHoliday")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("hoursPerWeek")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WorkSchedule");
                });

            modelBuilder.Entity("Core.Entities.Tk3User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("firstName")
                        .HasColumnType("TEXT");

                    b.Property<int>("forignId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("hashKey")
                        .HasColumnType("BLOB");

                    b.Property<string>("lastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("middleName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("BLOB");

                    b.Property<string>("userName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Tk3User");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Employee", b =>
                {
                    b.HasBaseType("Core.Entities.Tk3User");

                    b.Property<DateTime?>("accuralDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("departmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("locationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("teminationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.Property<int?>("workScheduleId")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.DepartmentsEmployees", b =>
                {
                    b.HasOne("Core.Entities.TimeSheets.Departments", "Departments")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TimeSheets.Employee", "Employees")
                        .WithMany("Departments")
                        .HasForeignKey("EmpoyeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.HolidayEmployee", b =>
                {
                    b.HasOne("Core.Entities.TimeSheets.Holidays", "Holiday")
                        .WithMany()
                        .HasForeignKey("holidayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TimeSheets.Timesheet", "Timesheet")
                        .WithMany("Holidays")
                        .HasForeignKey("timesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Holiday");

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.LeaveTransactions", b =>
                {
                    b.HasOne("Core.Entities.TimeSheets.LeaveBank", "Bank")
                        .WithMany()
                        .HasForeignKey("bankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TimeSheets.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Signatures", b =>
                {
                    b.HasOne("Core.Entities.TimeSheets.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimeDetails", b =>
                {
                    b.HasOne("Core.Entities.TimeSheets.ProjectCode", "ProjectCode")
                        .WithMany()
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TimeSheets.Timesheet", null)
                        .WithMany("TimeDetails")
                        .HasForeignKey("timesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectCode");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimeDetailsComments", b =>
                {
                    b.HasOne("Core.Entities.TimeSheets.TimeDetails", "TimeDetails")
                        .WithMany("Comments")
                        .HasForeignKey("timeDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TimeSheets.Timesheet", "Timesheet")
                        .WithMany()
                        .HasForeignKey("timesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeDetails");

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimeLunch", b =>
                {
                    b.HasOne("Core.Entities.TimeSheets.Timesheet", "Timesheet")
                        .WithMany("TimeLunch")
                        .HasForeignKey("timesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Timesheet", b =>
                {
                    b.HasOne("Core.Entities.TimeSheets.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimesheetExceptions", b =>
                {
                    b.HasOne("Core.Entities.TimeSheets.Employee", "Supervisor")
                        .WithMany()
                        .HasForeignKey("supervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TimeSheets.Timesheet", "Timesheet")
                        .WithMany()
                        .HasForeignKey("timesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supervisor");

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimesheetProjects", b =>
                {
                    b.HasOne("Core.Entities.TimeSheets.ProjectCode", "ProjectCode")
                        .WithMany("Timesheets")
                        .HasForeignKey("ProjectCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TimeSheets.Timesheet", "Timesheet")
                        .WithMany("Projects")
                        .HasForeignKey("TimesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectCode");

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Departments", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.ProjectCode", b =>
                {
                    b.Navigation("Timesheets");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.TimeDetails", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Timesheet", b =>
                {
                    b.Navigation("Holidays");

                    b.Navigation("Projects");

                    b.Navigation("TimeDetails");

                    b.Navigation("TimeLunch");
                });

            modelBuilder.Entity("Core.Entities.TimeSheets.Employee", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
