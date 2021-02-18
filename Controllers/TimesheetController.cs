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
    [Authorize]
    public class TimesheetController : Tk3BaseController
    {
        private readonly ITimesheetRepository _tsRepo;

        public TimesheetController(ITimesheetRepository tsRepo)
        {
            _tsRepo = tsRepo;
        }

        [HttpGet("get/{timesheetId}")]
        public async Task<ActionResult<TimesheetDto>> GetTimesheet(string guid)
        {
            var tso = await _tsRepo.GetTimesheet(new Guid(guid));
            if(tso != null) return Ok(tso);

            return BadRequest("Invalid timsheet code");
        }

        [HttpGet("new")]
        public async Task<ActionResult<TimesheetDto>> Create()
        {
            var user = new Tk3User();
            var tso = await _tsRepo.CreateTimesheet(user);
            return Ok(tso);
        }
        
    }
}
