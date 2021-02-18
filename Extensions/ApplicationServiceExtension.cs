using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.Data;
using tk3full.Interfaces;
using tk3full.Services;
using tk3full.Helpers;

namespace tk3full.Extensions
{
    public static class ApplicationServiceExtension
    {
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IMenuRepository, MenuRepository>();
			services.AddScoped<ITimesheetRepository, TimesheetRepository>();
			services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
			services.AddDbContext<DataContext>(options =>
			{
				options.UseSqlite(config.GetConnectionString("DefaultConnection"));
			});

			return services;
		}
	}
}
