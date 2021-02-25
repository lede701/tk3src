using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs;
using tk3full.DTOs.Timesheets;
using tk3full.Entities;
using tk3full.Entities.TimeSheets;

namespace tk3full.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Tk3User, UserDto>();
			CreateMap<MenuItem, MenuItemDto>();
			CreateMap<Timesheet, TimesheetDto>();
			CreateMap<Timesheet, TimesheetListDto>();
			CreateMap<TimeDetails, TimeDetailsDto>();
			CreateMap<TimeDetailsComments, TimeDetailsCommentsDto>();
			CreateMap<TimeLunch, TimeLunchDto>();
			CreateMap<ProjectCode, ProjectCodeDto>();
		}
	}
}
