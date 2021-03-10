using API.DTOs.Timesheets;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class TimeDetailsController : CoreController
	{
		private readonly IUnitOfWork _uow;

		public TimeDetailsController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		[HttpGet("get/{tsguid}")]
		public async Task<ActionResult<IReadOnlyCollection<TimeDetailsDto>>> GetDetails(String tsguid)
		{
			var ts = await _uow.TimesheetsRepository.GetByGuidAsync(Guid.Parse(tsguid));
			var td = await _uow.TimeDetailsRepository.ListAllBySpecAsync(new TimeDetailsSpec(ts.Id));
			if(td != null) return Ok(_uow.Mapper.Map<IReadOnlyCollection<TimeDetailsDto>>(td));

			return BadRequest("ERROR: Found in system it was not");
		}

		[HttpPost("update")]
		public async Task<ActionResult<TimeDetailsDto>> Update(TimeDetailsDto td)
		{

			return Ok(td);
		}
	}
}
