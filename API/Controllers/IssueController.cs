using API.DTOs.Structure;
using API.Extensions;
using Core.Entities.Structure;
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

		[HttpPost("add/{guid}")]
		public async Task<ActionResult<IssueDto>> AddComment(String guid, IssueCommentsDto comment)
		{
			var issue = await _uow.IssueRepository.GetByGuidAsync(Guid.Parse(guid));
			var user = await User.GetUserAsync(_uow.UserRepository);
			if(issue == null) BadRequest("Error there was in adding comment to issue");
			if (comment.guid == Guid.Empty)
			{
				issue.Comments.Add(new IssueComments()
				{
					guid = Guid.NewGuid(),
					Comment = comment.Comment,
					Rating = comment.Rating,
					Created = DateTime.Now,
					CreatedById = user.Id,
					Modified = DateTime.Now,
					ModifiedById = user.Id
				});
			}

			_uow.IssueRepository.Update(issue);
			await _uow.CompleteAsync();
			return Ok(_uow.Mapper.Map<IssueDto>(issue));
				
		}
			
	}
}
