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

		public TimesheetController(ITimesheetRepository tsRepo, IProjectRepository projectRepo,
            IMapper mapper, IUserRepository userRepo)
        {
            _tsRepo = tsRepo;
			_projectRepo = projectRepo;
			_mapper = mapper;
			_userRepo = userRepo;
		}

        [HttpGet("get/{guid}")]
        public async Task<ActionResult<TimesheetDto>> GetTimesheet(string guid)
        {
            // Pull object out of database
            TimesheetDto tso = await _tsRepo.GetTimesheetDtoAsync(new Guid(guid));
            // Check if a valid object was found
            if(tso != null) return Ok(tso);

            // No valid object so send an error
            return BadRequest("ERROR: Invalid timsheet code");
        }

        [HttpGet("new/{start}/{end}")]
        public async Task<ActionResult<TimesheetDto>> Create(DateTime start, DateTime end)
        {
            var user = await _userRepo.FindAsync(1);
            var tso = await _tsRepo.CreateTimesheetAsync(user, start, end);
            if (tso != null) return Ok(tso);

            return BadRequest("ERROR: Could not create timesheet");
        }

        [HttpPost("project/add/{tsGuid}/{projectGuid}")]
        public async Task<ActionResult<TimeDetailsDto>> AddTime(Guid tsGuid, Guid projectGuid, decimal time, DateTime day, string? comment)
		{
            var project = await _projectRepo.FindAsync(projectGuid);
            var ts = await _tsRepo.FindAsync(tsGuid);

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

            if(await _tsRepo.AddTimeAsync(td, ts))
			{
                if(comment?.Length > 0)
				{
                    await _tsRepo.AddCommentAsync(td, comment);
				}

                td = await _tsRepo.GetDetails(td.guid);

                return Ok(_mapper.Map<TimeDetailsDto>(td));
			}

            return BadRequest("ERROR: Could not add time to timesheet");
		}
        [HttpPost("lunch/add/{tsGuid}")]
        public async Task<ActionResult<TimeLunchDto>> AddLunch(Guid tsGuid, decimal time, DateTime day)
        {
            Timesheet ts = await _tsRepo.FindAsync(tsGuid);
            return await _tsRepo.AddLunchAsync(ts, time, day);
            
        }

    }
}
