using API.Errors;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class BuggyController : CoreController
	{
		private readonly IUnitOfWork _uow;

		public BuggyController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		[HttpGet("testauth")]
		[Authorize]
		public ActionResult<String> GetSecretText()
		{
			return "You are amazing!";
		}

		[HttpGet("notfound")]
		public ActionResult GetNotFoundRequest()
		{
			return NotFound(new ApiResponse(404));
		}

		[HttpGet("servererror")]
		public async Task<ActionResult> GetServerError()
		{
			var thing = await _uow.MenusRepository.GetByIdAsync(-1);
			var strToReturn = thing.ToString();

			return Ok();
		}

		[HttpGet("badrequest")]
		public ActionResult GetBadRequest()
		{
			return BadRequest(new ApiResponse(400));
		}

		[HttpGet("badrequest/{id}")]
		public ActionResult GetNotFoundRequest(int id)
		{
			return Ok();
		}
	}
}
