using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.Data;
using tk3full.DTOs.Timesheets;
using tk3full.Entities;
using tk3full.Interfaces;

namespace tk3full.Controllers
{
    //[Authorize]
    public class TimesheetController : Tk3BaseController
    {
        private readonly ITimesheetRepository _tsRepo;
		private readonly IProjectRepository _projectRepo;
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepo;
		private readonly IUnitOfWork _uow;

		public TimesheetController(IUnitOfWork uow)
        {
			_uow = uow;
		}

        [HttpGet("get/{guid}")]
        public async Task<ActionResult<TimesheetDto>> GetTimesheet(string guid)
        {
            // Pull object out of database
            TimesheetDto tso = await _uow.TimesheetRepositoy.GetTimesheetDtoAsync(new Guid(guid));
            // Check if a valid object was found
            if(tso != null) return Ok(tso);

            // No valid object so send an error
            return BadRequest("ERROR: Invalid timsheet code");
        }

        [HttpGet("new/{start}/{end}")]
        public async Task<ActionResult<TimesheetDto>> Create(DateTime start, DateTime end)
        {
            var user = await _uow.UserRepository.FindAsync(1);
            var tso = await _uow.TimesheetRepositoy.CreateTimesheetAsync(user, start, end);
            if (tso != null) return Ok(tso);

            return BadRequest("ERROR: Could not create timesheet");
        }

        [HttpPost("project/create/{tsGuid}/{projectGuid}")]
        public async Task<ActionResult<TimeDetailsDto>> AddTime(Guid tsGuid, Guid projectGuid, decimal time, DateTime day, string? comment)
		{
            var project = await _uow.ProjectRepositoy.FindAsync(projectGuid);
            var ts = await _uow.TimesheetRepositoy.FindAsync(tsGuid);

            if (project == null) return BadRequest("ERROR: Invalid project code");
            if (ts == null) return BadRequest("ERROR: Invalid timesheet code");

            var td = new TimeDetails()
            {
                guid = Guid.NewGuid(),
                projectId = project.id,
                timeDate = day,
                hrWorked = time,
                status = RecordStatus.ACTIVE
            };

            // TODO: Refactor so we reduce database connection
            if(await _uow.TimesheetRepositoy.AddTimeAsync(td, ts))
			{
                if(comment?.Length > 0)
				{
                    await _uow.TimesheetRepositoy.AddCommentAsync(td, comment);
				}

                td = await _uow.TimesheetRepositoy.GetDetails(td.guid);

                return Ok(_uow.Mapper.Map<TimeDetailsDto>(td));
			}

            return BadRequest("ERROR: Could not add time to timesheet");
		}
        [HttpPost("lunch/create/{tsGuid}")]
        public async Task<ActionResult<TimeLunchDto>> AddLunch(Guid tsGuid, decimal time, DateTime day)
        {
            Timesheet ts = await _uow.TimesheetRepositoy.FindAsync(tsGuid);
            var results = await _uow.TimesheetRepositoy.AddLunchAsync(ts, time, day);
            if (await _uow.Complete())
            {
                return results;
            }

            return BadRequest("ERROR: Could not add lunch time to timesheet");
        }

    }
}
