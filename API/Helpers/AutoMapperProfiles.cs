using API.DTOs;
using API.DTOs.Timesheets;
using AutoMapper;
using Core.Entities;
using Core.Entities.TimeSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
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
