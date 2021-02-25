using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using tk3full.Entities;
using tk3full.Entities.TimeSheets;

namespace tk3full.Data
{
	public class Seed
	{
		public static async Task SeedUsers(DataContext ctx)
		{
			if (await ctx.Users.AnyAsync()) return;

			using var hmac = new HMACSHA512();

			var user = new Tk3User()
			{
				guId = Guid.NewGuid(),
				userName = "lede",
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("test1234")),
				hashKey = hmac.Key,
				firstName = "Leland",
				middleName = "",
				lastName = "Ede",
				title = "Web/Database Developer",
				workScheduleId = 1,
				workHoursPerWeek = 40.0m,
				created = DateTime.Now,
				modified = DateTime.Now,
				status = 1
			};
			ctx.Add(user);
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
				created = DateTime.Now,
				createdBy = 1,
				modified = DateTime.Now,
				modifiedBy = 1,
				status = 1
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
				created = DateTime.Now,
				createdBy = 1,
				modified = DateTime.Now,
				modifiedBy = 1,
				status = 1
			});
			await ctx.SaveChangesAsync();
		}

		public static async Task SeedTimesheets(DataContext ctx)
		{
			ctx.Timesheet.Add(new Timesheet()
			{
				userId = 1,
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
				userId = 1,
				startDate = DateTime.Parse("2021-03-01"),
				endDate = DateTime.Parse("2021-03-15"),
				firstName = "Leland",
				middleName = "",
				lastname = "Ede",
				employeeStatus = 1,
				guid = Guid.NewGuid(),
				positionDescription = "Full stack developer"
			});
		}
	}
}
