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
using Core.Entities.Structure;

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
			try
			{
				await SeedIssues(ctx);
			}
			catch (Exception ex)
			{
				var logger = logFactory.CreateLogger<Seed>();
				logger.LogError(ex.Message);
			}
		}

		public static T AutoFill<T>(T item) where T : CoreEntity
		{
			item.guid = Guid.NewGuid();
			item.OrginizationGuid = OrgGuid;
			item.Created = DateTime.Now;
			item.CreatedById = 1;
			item.Modified = DateTime.Now;
			item.ModifiedById = 1;
			item.StatusCode = RecordStatus.ACTIVE;
			return item;
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

			var emp = AutoFill(new Employee()
			{
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
			});

			ctx.Add(emp);
			await ctx.SaveChangesAsync();

			var loc = AutoFill(new Locations()
			{
				locationCity = "Reno",
				locationState = "Nevada",
			});
			ctx.Add(loc);
			await ctx.SaveChangesAsync();

			var dept = AutoFill(new Departments()
			{
				name = "Administration",
				departmentCode = "ADM",
				deptParams = ""
			});
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

			ctx.Menu.Add(AutoFill(new MenuItem()
			{
				name = "Leave",
				route = "leave/",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 10,
				isHome = false,
			}));

			List<MenuItem> tsKids = new List<MenuItem>();
			tsKids.Add(AutoFill(new MenuItem()
			{
				name = "Sheet View",
				route = "/sheetview",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 200,
				isHome = false,
			}));

			ctx.Menu.Add(AutoFill(new MenuItem()
			{
				name = "Timesheets",
				route = "",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 20,
				isHome = false,
				Children = tsKids
			}));

			tsKids = new List<MenuItem>();
			tsKids.Add(AutoFill(new MenuItem()
			{
				name = "Add Project",
				route = "/projects/edit",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 300,
				isHome = false,
			}));
			
			tsKids.Add(AutoFill(new MenuItem()
			{
				name = "Project List",
				route = "/projects",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 310,
				isHome = false,
			}));

			ctx.Menu.Add(AutoFill(new MenuItem()
			{
				name = "Projects",
				route = "",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 30,
				isHome = false,
				Children = tsKids
			}));

			// Create children items for tools drop down menu
			tsKids = new List<MenuItem>();
			tsKids.Add(AutoFill(new MenuItem()
			{
				name = "User Manager",
				route = "/tools/users",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 410,
				isHome = false,
			}));
			tsKids.Add(AutoFill(new MenuItem()
			{
				name = "Menu Manager",
				route = "/tools/navbar",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 400,
				isHome = false,
			}));
			tsKids.Add(AutoFill(new MenuItem()
			{
				name = "Issue Tracker",
				route = "/tools/issues",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 420,
				isHome = false,
			}));
			ctx.Menu.Add(AutoFill(new MenuItem()
			{
				name = "Tools",
				route = "",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 40,
				isHome = false,
				Children = tsKids
			}));
			await ctx.SaveChangesAsync();
		}

		public static async Task SeedTimesheets(DataContext ctx)
		{
			if (await ctx.Timesheet.AnyAsync()) return;

			ctx.ProjectCode.Add(AutoFill(new ProjectCode()
			{
				commentType = 1,
				ProjectTitle = "12021-00",
				ProjectDescription = "General Operations",
			}));

			ctx.ProjectCode.Add(AutoFill(new ProjectCode()
			{
				commentType = 1,
				ProjectTitle = "12121-00",
				ProjectDescription = "Proposal Development",
			}));

			ctx.Timesheet.Add(AutoFill(new Timesheet()
			{
				employeeId = 1,
				startDate = DateTime.Parse("2021-02-16"),
				endDate = DateTime.Parse("2021-02-28"),
				firstName = "Leland",
				middleName = "",
				lastname = "Ede",
				employeeStatus = 1,
				positionDescription = "Full stack developer",
			}));
			ctx.Timesheet.Add(AutoFill(new Timesheet()
			{
				employeeId = 1,
				startDate = DateTime.Parse("2021-03-01"),
				endDate = DateTime.Parse("2021-03-15"),
				firstName = "Leland",
				middleName = "",
				lastname = "Ede",
				employeeStatus = 1,
				positionDescription = "Full stack developer",
			}));
			ctx.Timesheet.Add(AutoFill(new Timesheet()
			{
				employeeId = 1,
				startDate = DateTime.Parse("2021-03-16"),
				endDate = DateTime.Parse("2021-03-31"),
				firstName = "Leland",
				middleName = "",
				lastname = "Ede",
				employeeStatus = 1,
				positionDescription = "Full stack developer",
			}));
			await ctx.SaveChangesAsync();

			var ts = await ctx.Timesheet.Where(ts => ts.employeeId == 1 && ts.startDate == Convert.ToDateTime("2021-02-16"))
				.FirstOrDefaultAsync();

			ts.TimeDetails.Add(AutoFill(
				new TimeDetails
				{
					timesheetId = ts.Id,
					projectId = 1,
					timeDate = Convert.ToDateTime("2021-02-16"),
					hrWorked = 8.2m,
				}));
			ts.TimeDetails.Add(AutoFill(new TimeDetails()
			{
				timesheetId = ts.Id,
				projectId = 1,
				timeDate = Convert.ToDateTime("2021-02-17"),
				hrWorked = 8.0m,
			}));
			await ctx.SaveChangesAsync();
		}

		public static async Task SeedLeave(DataContext ctx)
		{
			if (await ctx.LeaveBank.AnyAsync()) return;

			ctx.LeaveBank.Add(AutoFill(new LeaveBank()
			{
				displayCode = "AL",
				bankDescription = "Annual Leave",
				expiresInDays = 365,
			}));
			ctx.LeaveBank.Add(AutoFill(new LeaveBank()
			{
				displayCode = "SL",
				bankDescription = "Sick Leave",
				expiresInDays = 365,
			}));
			ctx.LeaveBank.Add(AutoFill(new LeaveBank()
			{
				displayCode = "PTO",
				bankDescription = "Paid Time Off",
				expiresInDays = 365,
			}));
			await ctx.SaveChangesAsync();

			// Add leave records
			ctx.LeaveTansactions.Add(AutoFill(new LeaveTransactions()
			{
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
			}));
			ctx.LeaveTansactions.Add(AutoFill(new LeaveTransactions()
			{
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
			}));
			await ctx.SaveChangesAsync();
		}

		public static async Task SeedIssues(DataContext ctx)
		{
			if (await ctx.IssueTypes.AnyAsync()) return;

			ctx.IssueTypes.Add(AutoFill(new IssueType()
			{
				TypeTag = "New"
			}));

			ctx.IssueTypes.Add(AutoFill(new IssueType()
			{
				TypeTag = "Scheduled"
			}));
			ctx.IssueTypes.Add(AutoFill(new IssueType()
			{
				TypeTag = "Bug",
			}));
			ctx.IssueTypes.Add(AutoFill(new IssueType()
			{
				TypeTag = "Feature Request",
			}));
			ctx.IssueTypes.Add(AutoFill(new IssueType()
			{
				TypeTag = "Ready to Test",
			}));
			ctx.IssueTypes.Add(AutoFill(new IssueType()
			{
				TypeTag = "Completed",
			}));
			await ctx.SaveChangesAsync();

			var itype = await ctx.IssueTypes.Where(it => it.TypeTag == "New").FirstOrDefaultAsync();

			ctx.Issues.Add(AutoFill(new Issue()
			{
				IssueTitle = "New Test Issue",
				IssueDescription = "This is a test issue to see how the issue system is working!",
				IssueType = itype,
				Severity = 1
			}));

			await ctx.SaveChangesAsync();
		}
	}
}
