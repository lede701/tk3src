using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.TimeSheets;

namespace Framework.Data
{
	public class Seed
	{
		public static async Task SeedData(DataContext ctx, ILoggerFactory logFactory)
		{
			try
			{
				await SeedUsers(ctx);
			}catch(Exception ex)
			{
				var logger = logFactory.CreateLogger<Seed>();
				logger.LogError(ex.Message);
			}
			try
			{
				await SeedMenu(ctx);
			}catch(Exception ex)
			{
				var logger = logFactory.CreateLogger<Seed>();
				logger.LogError(ex.Message);
			}
			try
			{
				await SeedTimesheets(ctx);
			}catch(Exception ex)
			{
				var logger = logFactory.CreateLogger<Seed>();
				logger.LogError(ex.Message);
			}
		}

		public static async Task SeedUsers(DataContext ctx)
		{
			if (await ctx.Users.AnyAsync()) return;

			using var hmac = new HMACSHA512();

			var emp = new Employee()
			{
				guid = Guid.NewGuid(),
				userName = "lede",
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("test1234")),
				hashKey = hmac.Key,
				firstName = "Leland",
				middleName = "",
				lastName = "Ede",
				title = "Full Stack Developer",
				locationId = 1,
				departmentId = 1,
				workScheduleId = 1,
				startDate = DateTime.Now,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			};

			ctx.Add(emp);
			await ctx.SaveChangesAsync();

			var loc = new Locations()
			{
				guid = Guid.NewGuid(),
				locationCity = "Reno",
				locationState = "Nevada",
				StatusCode = RecordStatus.ACTIVE
			};
			ctx.Add(loc);
			await ctx.SaveChangesAsync();

			var dept = new Departments()
			{
				guid = Guid.NewGuid(),
				name = "Administration",
				departmentCode = "ADM",
				StatusCode = RecordStatus.ACTIVE,
				deptParams = ""
			};
			ctx.Add(dept);
			await ctx.SaveChangesAsync();

			var de = new DepartmentsEmployees()
			{
				Departments = dept,
				Employees = emp
			};
			emp.Departments.Add(de);

			await ctx.SaveChangesAsync();
		}

		public static async Task SeedMenu(DataContext ctx)
		{
			if (await ctx.Menu.AnyAsync()) return;

			ctx.Menu.Add(new MenuItem()
			{
				parentId = 0,
				name = "Home",
				route = "/",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 1,
				isHome = true,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			ctx.Menu.Add(new MenuItem()
			{
				parentId = 0,
				name = "Timesheet",
				route = "timesheet/",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 1,
				isHome = true,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			await ctx.SaveChangesAsync();
		}

		public static async Task SeedTimesheets(DataContext ctx)
		{
			if (await ctx.Timesheet.AnyAsync()) return;

			ctx.ProjectCode.Add(new ProjectCode()
			{
				guid = Guid.NewGuid(),
				commentType = 1,
				ProjectTitle = "12021-00",
				ProjectDescription = "General Operations",
				StatusCode = RecordStatus.ACTIVE,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1
			});

			ctx.Timesheet.Add(new Timesheet()
			{
				employeeId = 1,
				startDate = DateTime.Parse("2021-02-16"),
				endDate = DateTime.Parse("2021-02-28"),
				firstName = "Leland",
				middleName = "",
				lastname = "Ede",
				employeeStatus = 1,
				guid = Guid.NewGuid(),
				positionDescription = "Full stack developer"
			});
			ctx.Timesheet.Add(new Timesheet()
			{
				employeeId = 1,
				startDate = DateTime.Parse("2021-03-01"),
				endDate = DateTime.Parse("2021-03-15"),
				firstName = "Leland",
				middleName = "",
				lastname = "Ede",
				employeeStatus = 1,
				guid = Guid.NewGuid(),
				positionDescription = "Full stack developer"
			});
			await ctx.SaveChangesAsync();
			var ts = await ctx.Timesheet.Where(ts => ts.employeeId == 1)
				.FirstOrDefaultAsync();
			ts.TimeDetails.Add(
				new TimeDetails
				{
					timesheetId = ts.Id,
					projectId = 1,
					timeDate = Convert.ToDateTime("2021-02-16"),
					hrWorked = 8.2m
				});
			ts.TimeDetails.Add(new TimeDetails()
			{
				timesheetId = ts.Id,
				projectId = 1,
				timeDate = Convert.ToDateTime("2021-02-17"),
				hrWorked = 8.0m

			});
			await ctx.SaveChangesAsync();
		}
	}
}
