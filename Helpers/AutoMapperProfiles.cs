using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs;
using tk3full.DTOs.Timesheets;
using tk3full.Entities;

namespace tk3full.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Tk3User, UserDto>();
			CreateMap<MenuItem, MenuItemDto>();
			CreateMap<Timesheet, TimesheetDto>();
		}
	}
}
