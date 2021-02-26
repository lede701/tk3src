﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tk3full.Data;

namespace tk3full.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210226225256_AddingTSTables")]
    partial class AddingTSTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("tk3full.Entities.MenuItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("alias")
                        .HasColumnType("TEXT");

                    b.Property<int>("checked_out")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("checked_out_time")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<int>("createdBy")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isHome")
                        .HasColumnType("INTEGER");

                    b.Property<string>("menuParams")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("INTEGER");

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

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("type")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("createdBy");

                    b.HasIndex("modifiedBy");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.Departments", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("departmentCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("deptParams")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.HolidayEmployee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("id");

                    b.HasIndex("holidayId");

                    b.HasIndex("timesheetId");

                    b.ToTable("HolidayEmployee");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.Holidays", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("holidayDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("holidayDescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("locationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.LeaveAccural", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("earnedHours")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("endYear")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("maxHours")
                        .HasColumnType("TEXT");

                    b.Property<int>("rateGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("startYear")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("LeaveAccrual");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.LeaveBank", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("bankDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("displayCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("expiresInDays")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("LeaveBank");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.LeaveTransactions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("approved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("bankId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("displayDate")
                        .HasColumnType("TEXT");

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

                    b.Property<DateTime>("modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("parentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("tranDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("tranTime")
                        .HasColumnType("TEXT");

                    b.Property<char>("tranType")
                        .HasColumnType("TEXT");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("bankId");

                    b.HasIndex("userId");

                    b.ToTable("LeaveTansactions");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.Locations", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<string>("locationCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("locationState")
                        .HasColumnType("TEXT");

                    b.Property<int>("parentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("parentId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.ProjectCode", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectTitle")
                        .HasColumnType("TEXT");

                    b.Property<int>("commentType")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<int>("createdBy")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("createdBy");

                    b.HasIndex("modifiedBy");

                    b.ToTable("ProjectCode");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.Signatures", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dateExpire")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isLocked")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("lastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("signatureHash")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Signatures");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.TimeDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("hrWorked")
                        .HasColumnType("TEXT");

                    b.Property<int>("projectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("timeDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("timesheetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("projectId");

                    b.HasIndex("timesheetId");

                    b.ToTable("TimeDetails");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.TimeDetailsComments", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("timeDetailsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("timesheetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("timeDetailsId");

                    b.HasIndex("timesheetId");

                    b.ToTable("TimeDetailsComments");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.TimeLunch", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lunchDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("lunchTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("timesheetId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("timesheetId");

                    b.ToTable("TimeLunch");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.Timesheet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("earlySign")
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

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Timesheet");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.TimesheetExceptions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("approved")
                        .HasColumnType("INTEGER");

                    b.Property<string>("comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<string>("employeeComment")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("guid")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("modified")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

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

                    b.HasKey("id");

                    b.HasIndex("supervisorId");

                    b.HasIndex("timesheetId");

                    b.ToTable("TimesheetExceptions");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.WorkSchedule", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("id");

                    b.ToTable("WorkSchedule");
                });

            modelBuilder.Entity("tk3full.Entities.Tk3User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("created")
                        .HasColumnType("TEXT");

                    b.Property<int>("departmentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("firstName")
                        .HasColumnType("TEXT");

                    b.Property<int>("forignId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("guId")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("hashKey")
                        .HasColumnType("BLOB");

                    b.Property<string>("lastName")
                        .HasColumnType("TEXT");

                    b.Property<int>("locationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("middleName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("modified")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("passwordHash")
                        .HasColumnType("BLOB");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("title")
                        .HasColumnType("TEXT");

                    b.Property<string>("userName")
                        .HasColumnType("TEXT");

                    b.Property<string>("userParams")
                        .HasColumnType("TEXT");

                    b.Property<int>("workScheduleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("tk3full.Entities.MenuItem", b =>
                {
                    b.HasOne("tk3full.Entities.Tk3User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("createdBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tk3full.Entities.Tk3User", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("modifiedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("ModifiedUser");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.HolidayEmployee", b =>
                {
                    b.HasOne("tk3full.Entities.TimeSheets.Holidays", "Holiday")
                        .WithMany()
                        .HasForeignKey("holidayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tk3full.Entities.TimeSheets.Timesheet", "Timesheet")
                        .WithMany("Holidays")
                        .HasForeignKey("timesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Holiday");

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.LeaveTransactions", b =>
                {
                    b.HasOne("tk3full.Entities.TimeSheets.LeaveBank", "Bank")
                        .WithMany()
                        .HasForeignKey("bankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tk3full.Entities.Tk3User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("User");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.Locations", b =>
                {
                    b.HasOne("tk3full.Entities.TimeSheets.Locations", "parent")
                        .WithMany()
                        .HasForeignKey("parentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("parent");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.ProjectCode", b =>
                {
                    b.HasOne("tk3full.Entities.Tk3User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("createdBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tk3full.Entities.Tk3User", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("modifiedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("ModifiedUser");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.Signatures", b =>
                {
                    b.HasOne("tk3full.Entities.Tk3User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.TimeDetails", b =>
                {
                    b.HasOne("tk3full.Entities.TimeSheets.ProjectCode", "ProjectCode")
                        .WithMany()
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tk3full.Entities.TimeSheets.Timesheet", null)
                        .WithMany("TimeDetails")
                        .HasForeignKey("timesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectCode");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.TimeDetailsComments", b =>
                {
                    b.HasOne("tk3full.Entities.TimeSheets.TimeDetails", "TimeDetails")
                        .WithMany("Comments")
                        .HasForeignKey("timeDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tk3full.Entities.TimeSheets.Timesheet", "Timesheet")
                        .WithMany()
                        .HasForeignKey("timesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeDetails");

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.TimeLunch", b =>
                {
                    b.HasOne("tk3full.Entities.TimeSheets.Timesheet", "Timesheet")
                        .WithMany("TimeLunch")
                        .HasForeignKey("timesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.Timesheet", b =>
                {
                    b.HasOne("tk3full.Entities.Tk3User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.TimesheetExceptions", b =>
                {
                    b.HasOne("tk3full.Entities.Tk3User", "Supervisor")
                        .WithMany()
                        .HasForeignKey("supervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tk3full.Entities.TimeSheets.Timesheet", "Timesheet")
                        .WithMany()
                        .HasForeignKey("timesheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supervisor");

                    b.Navigation("Timesheet");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.TimeDetails", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("tk3full.Entities.TimeSheets.Timesheet", b =>
                {
                    b.Navigation("Holidays");

                    b.Navigation("TimeDetails");

                    b.Navigation("TimeLunch");
                });
#pragma warning restore 612, 618
        }
    }
}
