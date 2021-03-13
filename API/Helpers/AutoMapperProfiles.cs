using API.DTOs;
using API.DTOs.Structure;
using API.DTOs.Timesheets;
using AutoMapper;
using Core.Entities;
using Core.Entities.Structure;
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
			CreateMap<Employee, UserDto>();
			CreateMap<Tk3User, UserListDto>();
			CreateMap<Employee, UserListDto>();
			CreateMap<MenuItem, MenuItemDto>().ReverseMap();
			CreateMap<Issue, IssueDto>().ReverseMap();
			CreateMap<IssueType, IssueTypeDto>().ReverseMap();
			CreateMap<IssueComments, IssueCommentsDto>().ReverseMap();
			MapTimesheets();
			MapLeave();
			MapProjects();
		}

		private void MapTimesheets()
		{
			CreateMap<Timesheet, TimesheetDto>();
			CreateMap<Timesheet, TimesheetListDto>();
			CreateMap<TimeDetails, TimeDetailsDto>();
			CreateMap<TimeDetailsComments, TimeDetailsCommentsDto>();
			CreateMap<TimeLunch, TimeLunchDto>();
		}

		private void MapLeave()
		{
			CreateMap<LeaveTransactions, LeaveTransactionDto>()
				.ForMember(lt => lt.BankCode, b => b.MapFrom(m => m.Bank.displayCode))
				.ForMember(lt => lt.BankName, b => b.MapFrom(m => m.Bank.bankDescription));
		}

		private void MapProjects()
		{
			CreateMap<ProjectCode, ProjectCodeDto>();
		}
	}
}
