using API.DTOs.Structure;
using Core.Interfaces;
using Core.Specifications.Structure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class IssueController : CoreController
	{
		private readonly IUnitOfWork _uow;

		public IssueController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		[HttpGet("list")]
		public async Task<ActionResult<IReadOnlyCollection<IssueDto>>> List()
		{
			var list = await _uow.IssueRepository.ListAllBySpecAsync(new IssueSpec());
			return Ok(_uow.Mapper.Map<IReadOnlyCollection<IssueDto>>(list));
		}
			
	}
}
