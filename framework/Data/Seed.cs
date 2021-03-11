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
		private static Guid OrgGuid;

		public static async Task SeedData(DataContext ctx, ILoggerFactory logFactory)
		{
			try
			{
				await SeedOrginization(ctx);
			}
			catch (Exception ex)
			{
				var logger = logFactory.CreateLogger<Seed>();
				logger.LogError(ex.Message);
			}
			try
			{
				await SeedUsers(ctx);
			}
			catch (Exception ex)
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
			}
			catch (Exception ex)
			{
				var logger = logFactory.CreateLogger<Seed>();
				logger.LogError(ex.Message);
			}
			try
			{
				await SeedLeave(ctx);
			}
			catch (Exception ex)
			{
				var logger = logFactory.CreateLogger<Seed>();
				logger.LogError(ex.Message);
			}
		}

		public static async Task SeedOrginization(DataContext ctx)
		{
			if (await ctx.Orginizations.AnyAsync())
			{
				var org = await ctx.Orginizations.FirstOrDefaultAsync();
				OrgGuid = org.guid;
				return;
			}

			OrgGuid = Guid.NewGuid();

			ctx.Orginizations.Add(new CoreOrginizationEntity()
			{
				guid = OrgGuid,
				OrginizationGuid = OrgGuid,
				OrginizationName = "Initial Orginization",
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			
		}

		public static async Task SeedUsers(DataContext ctx)
		{
			if (await ctx.Users.AnyAsync()) return;

			using var hmac = new HMACSHA512();

			var emp = new Employee()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
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
				OrginizationGuid = OrgGuid,
				locationCity = "Reno",
				locationState = "Nevada",
				StatusCode = RecordStatus.ACTIVE
			};
			ctx.Add(loc);
			await ctx.SaveChangesAsync();

			var dept = new Departments()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
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
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				name = "Leave",
				route = "leave/",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 10,
				isHome = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});

			List<MenuItem> tsKids = new List<MenuItem>();
			tsKids.Add(new MenuItem()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				name = "Sheet View",
				route = "/sheetview",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 200,
				isHome = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});

			ctx.Menu.Add(new MenuItem()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				name = "Timesheets",
				route = "",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 20,
				isHome = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE,
				Children = tsKids
			});

			tsKids = new List<MenuItem>();
			tsKids.Add(new MenuItem()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				name = "Add Project",
				route = "/projects/edit",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 300,
				isHome = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			}); tsKids.Add(new MenuItem()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				name = "Project List",
				route = "/projects",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 310,
				isHome = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});

			ctx.Menu.Add(new MenuItem()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				name = "Projects",
				route = "",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 30,
				isHome = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE,
				Children = tsKids
			});

			// Create children items for tools drop down menu
			tsKids = new List<MenuItem>();
			tsKids.Add(new MenuItem()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				name = "User Manager",
				route = "/tools/users",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 410,
				isHome = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			tsKids.Add(new MenuItem()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				name = "Menu Manager",
				route = "/tools/navbar",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 400,
				isHome = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});

			ctx.Menu.Add(new MenuItem()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				name = "Tools",
				route = "",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 40,
				isHome = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE,
				Children = tsKids
			});
			await ctx.SaveChangesAsync();
		}

		public static async Task SeedTimesheets(DataContext ctx)
		{
			if (await ctx.Timesheet.AnyAsync()) return;

			ctx.ProjectCode.Add(new ProjectCode()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				commentType = 1,
				ProjectTitle = "12021-00",
				ProjectDescription = "General Operations",
				StatusCode = RecordStatus.ACTIVE,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1
			});

			ctx.ProjectCode.Add(new ProjectCode()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				commentType = 1,
				ProjectTitle = "12121-00",
				ProjectDescription = "Proposal Development",
				StatusCode = RecordStatus.ACTIVE,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1
			});

			ctx.Timesheet.Add(new Timesheet()
			{
				OrginizationGuid = OrgGuid,
				employeeId = 1,
				startDate = DateTime.Parse("2021-02-16"),
				endDate = DateTime.Parse("2021-02-28"),
				firstName = "Leland",
				middleName = "",
				lastname = "Ede",
				employeeStatus = 1,
				guid = Guid.NewGuid(),
				positionDescription = "Full stack developer",
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			ctx.Timesheet.Add(new Timesheet()
			{
				OrginizationGuid = OrgGuid,
				employeeId = 1,
				startDate = DateTime.Parse("2021-03-01"),
				endDate = DateTime.Parse("2021-03-15"),
				firstName = "Leland",
				middleName = "",
				lastname = "Ede",
				employeeStatus = 1,
				guid = Guid.NewGuid(),
				positionDescription = "Full stack developer",
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			ctx.Timesheet.Add(new Timesheet()
			{
				OrginizationGuid = OrgGuid,
				employeeId = 1,
				startDate = DateTime.Parse("2021-03-16"),
				endDate = DateTime.Parse("2021-03-31"),
				firstName = "Leland",
				middleName = "",
				lastname = "Ede",
				employeeStatus = 1,
				guid = Guid.NewGuid(),
				positionDescription = "Full stack developer",
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			await ctx.SaveChangesAsync();
			var ts = await ctx.Timesheet.Where(ts => ts.employeeId == 1 && ts.startDate == Convert.ToDateTime("2021-02-16"))
				.FirstOrDefaultAsync();
			ts.TimeDetails.Add(
				new TimeDetails
				{
					guid = Guid.NewGuid(),
					OrginizationGuid = OrgGuid,
					timesheetId = ts.Id,
					projectId = 1,
					timeDate = Convert.ToDateTime("2021-02-16"),
					hrWorked = 8.2m,
					Created = DateTime.Now,
					CreatedById = 1,
					Modified = DateTime.Now,
					ModifiedById = 1,
					StatusCode = RecordStatus.ACTIVE

				});
			ts.TimeDetails.Add(new TimeDetails()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				timesheetId = ts.Id,
				projectId = 1,
				timeDate = Convert.ToDateTime("2021-02-17"),
				hrWorked = 8.0m,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			await ctx.SaveChangesAsync();
		}

		public static async Task SeedLeave(DataContext ctx)
		{
			if (await ctx.LeaveBank.AnyAsync()) return;

			ctx.LeaveBank.Add(new LeaveBank()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				displayCode = "AL",
				bankDescription = "Annual Leave",
				expiresInDays = 365,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			ctx.LeaveBank.Add(new LeaveBank()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				displayCode = "SL",
				bankDescription = "Sick Leave",
				expiresInDays = 365,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			ctx.LeaveBank.Add(new LeaveBank()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				displayCode = "PTO",
				bankDescription = "Paid Time Off",
				expiresInDays = 365,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			await ctx.SaveChangesAsync();

			// Add leave records
			ctx.LeaveTansactions.Add(new LeaveTransactions()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				parentId = 0,
				locationId = 0,
				employeeId = 1,
				bankId = 3,
				tranType = 'C',
				tranTime = 336,
				tranDate = DateTime.Now,
				displayDate = DateTime.Now,
				employeeSigned = true,
				approved = true,
				isAccrual = false,
				isParent = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			ctx.LeaveTansactions.Add(new LeaveTransactions()
			{
				guid = Guid.NewGuid(),
				OrginizationGuid = OrgGuid,
				parentId = 0,
				locationId = 0,
				employeeId = 1,
				bankId = 2,
				tranType = 'C',
				tranTime = 221,
				tranDate = DateTime.Now,
				displayDate = DateTime.Now,
				employeeSigned = true,
				approved = true,
				isAccrual = false,
				isParent = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			await ctx.SaveChangesAsync();
		}
	}
}
