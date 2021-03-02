using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tk3full.Entities;
using tk3full.Entities.TimeSheets;

namespace tk3full.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<DepartmentsEmployees>()
				.HasKey(de => new { de.DepartmentsId, de.EmpoyeesId });
			builder.Entity<DepartmentsEmployees>()
				.HasOne(de => de.Departments)
				.WithMany(d => d.Employees)
				.HasForeignKey(de => de.DepartmentsId);
			builder.Entity<DepartmentsEmployees>()
				.HasOne(de => de.Employees)
				.WithMany(e => e.Departments)
				.HasForeignKey(de => de.EmpoyeesId);

			/*
			builder.Entity<Locations>()
				.HasOne(loc => loc.Parent)
				.WithMany()
				.HasForeignKey(loc => loc.parentId);
			//*/
		}

		public DbSet<Departments> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Holidays> Holidays { get; set; }
		public DbSet<LeaveAccural> LeaveAccrual { get; set; }
		public DbSet<LeaveBank> LeaveBank { get; set; }
		public DbSet<LeaveTransactions> LeaveTansactions { get; set; }
		public DbSet<Locations> Locations { get; set; }
		public DbSet<MenuItem> Menu { get; set; }
		public DbSet<ProjectCode> ProjectCode { get; set; }
		public DbSet<Signatures> Signatures { get; set; }
		public DbSet<TimeDetails> TimeDetails { get; set; }
		public DbSet<TimeLunch> TimeLunch { get; set; }
		public DbSet<Timesheet> Timesheet { get; set; }
        public DbSet<TimeDetailsComments> TimeDetailsComments { get; set; }
		public DbSet<TimesheetExceptions> TimesheetExceptions { get; set; }
		public DbSet<WorkSchedule> WorkSchedule { get; set; }
		public DbSet<Tk3User> Users { get; set; }
	}
}
