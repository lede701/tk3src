using API.DTOs.Timesheets;
using API.Extensions;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Framework.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class LeaveController : CoreController
	{
		private readonly IUnitOfWork _uow;

		public LeaveController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		[HttpGet("list")]
		public async Task<ActionResult<IReadOnlyCollection<LeaveTransactionDto>>> ListUserLeave()
		{
			var guid = User.GetUserId();
			if (String.IsNullOrEmpty(guid)) return BadRequest("Found was not your user ID.");

			var user = await _uow.EmployeesRepository.GetByGuidAsync(Guid.Parse(guid));
			if (user != null)
			{
				var leave = await _uow.LeaveRepository.ListAllBySpecAsync(new LeaveForEmployeeSpec(user.Id));
				return Ok(_uow.Mapper.Map<IReadOnlyCollection<LeaveTransactionDto>>(leave));
			}

			return BadRequest("Found leave was not.");
		}

		/*
		[HttpGet("addmenu")]
		public async Task<ActionResult<String>> AddMenuItems()
		{
			_uow.MenusRepository.Add(new MenuItem()
			{
				guid = Guid.NewGuid(),
				name = "Leave",
				route = "/leave",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 4,
				checked_out = 0,
				checked_out_time = DateTime.MinValue,
				isHome = false,
				menuParams = "",
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});
			await _uow.CompleteAsync();
			return Ok("Added was Menu Item");
		}
		*/
	}
}
