﻿using API.DTOs.Timesheets;
using API.Extensions;
using AutoMapper;
using Core.Entities.TimeSheets;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]
    public class TimesheetController : CoreController
    {
		private readonly IUnitOfWork _uow;

		public TimesheetController(IUnitOfWork uow)
        {
			_uow = uow;
		}

        [HttpGet("get/{guid}")]
        public async Task<ActionResult<TimesheetDto>> GetTimesheet(string guid)
        {
            // Pull object out of database
            var tsWithSpec = await _uow.TimesheetsRepository.GetBySpecAsync(new TimesheetSpec(Guid.Parse(guid)));
            // Check if a valid object was found
            if(tsWithSpec != null) return Ok(_uow.Mapper.Map<TimesheetDto>(tsWithSpec));

            // No valid object so send an error
            return BadRequest("ERROR: Invalid timsheet");
        }

        [HttpGet("list")]
        public async Task<ActionResult<ICollection<TimesheetListDto>>> GetTimesheetList()
		{
            Employee emp = await _uow.EmployeesRepository.GetByGuidAsync(User.GetUserId());
            var data = await _uow.TimesheetsRepository.ListAllBySpecAsync(new TimesheetsForEmployeeSpec(emp.Id));

            //var data = await _uow.TimesheetsRepository.ListAllByUserAsync(emp.Id);
            //var data = await _uow.TimesheetRepositoy.GetTimesheetListAsync(emp);
            if(data != null)
			{
                return Ok(_uow.Mapper.Map<IReadOnlyCollection<TimesheetListDto>>(data));
			}
            return BadRequest("ERROR: No timesheets available to send back for current user");

		}

        [HttpGet("new/{start}/{end}")]
        public async Task<ActionResult<TimesheetDto>> Create(DateTime start, DateTime end)
        {
            Guid guid = User.GetUserId();
            var emp = await _uow.EmployeesRepository.GetByGuidAsync(guid);
            //var tso = await _uow.TimesheetRepositoy.CreateTimesheetAsync(emp, start, end);
            //if (tso != null) return Ok(tso);

            return BadRequest("ERROR: Could not create timesheet");
        }

        [HttpPost("project/create/{tsGuid}/{projectGuid}")]
        public async Task<ActionResult<TimeDetailsDto>> AddTime(Guid tsGuid, Guid projectGuid, decimal time, DateTime day, string? comment)
		{
            /*
            var project = await _uow.ProjectRepositoy.FindAsync(projectGuid);
            var ts = await _uow.TimesheetRepositoy.FindAsync(tsGuid);

            if (project == null) return BadRequest("ERROR: Invalid project code");
            if (ts == null) return BadRequest("ERROR: Invalid timesheet code");

            var td = new TimeDetails()
            {
                guid = Guid.NewGuid(),
                projectId = project.Id,
                timeDate = day,
                hrWorked = time,
                status = RecordStatus.ACTIVE
            };

            // Create time detail record and add it to the repository
            await _uow.TimesheetRepositoy.AddTimeAsync(td, ts);
            // Check if there is a comment that needs to be added
            if (comment?.Length > 0)
            {
                await _uow.TimesheetRepositoy.AddCommentAsync(td, comment);
            }
            // Check if complete is successful
            if(await _uow.Complete())
			{
                // Return DTO object!
                return Ok(_uow.Mapper.Map<TimeDetailsDto>(td));
            }
            */
            // Something really went wrong so let app know
            return BadRequest("ERROR: Could not add time to timesheet");
		}
        [HttpPost("lunch/create/{tsGuid}")]
        public async Task<ActionResult<TimeLunchDto>> AddLunch(Guid tsGuid, decimal time, DateTime day)
        {
            /*
            Timesheet ts = await _uow.TimesheetRepositoy.FindAsync(tsGuid);
            var results = await _uow.TimesheetRepositoy.AddLunchAsync(ts, time, day);
            if (await _uow.Complete())
            {
                return results;
            }
            */

            return BadRequest("ERROR: Could not add lunch time to timesheet");
        }

    }
}
