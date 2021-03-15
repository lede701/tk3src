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

		[HttpGet("get/{guid}")]
		public async Task<ActionResult<IssueDto>> GetIssue(String guid)
        {
			var issue = await _uow.IssueRepository.GetBySpecAsync(new IssueSpec(Guid.Parse(guid)));
			if (issue != null) return Ok(_uow.Mapper.Map<IssueDto>(issue));

			return BadRequest("ERROR: Issue found it was not.");
        }

		[HttpPost("comment/add/{guid}")]
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

		[HttpGet("comment/up")]
		public async Task<ActionResult<IssueCommentsDto>> CommentUp(String guid)
		{
			// Load comment from database
			var comment = await _uow.IssueCommentRepository.GetByGuidAsync(Guid.Parse(guid));

			// Check if we have a valid comment
			if (comment == null) return BadRequest("ERROR: Comment updated it was not.");
			// Update rating
			comment.Rating++;
			// Tell entiry framework the recrod was updaetd
			_uow.IssueCommentRepository.Update(comment);
			await _uow.CompleteAsync();

			return Ok(_uow.Mapper.Map<IssueCommentsDto>(comment));

		}

		[HttpGet("comment/down")]
		public async Task<ActionResult<IssueCommentsDto>> CommentDown(String guid)
		{
			// Load comment from database
			var comment = await _uow.IssueCommentRepository.GetByGuidAsync(Guid.Parse(guid));

			// Check if we have a valid comment
			if (comment == null) return BadRequest("ERROR: Comment updated it was not.");
			// Update rating
			comment.Rating = Math.Max(0, comment.Rating - 1);
			_uow.IssueCommentRepository.Update(comment);
			// Tell entiry framework the recrod was updaetd
			_uow.IssueCommentRepository.Update(comment);
			await _uow.CompleteAsync();

			return Ok(_uow.Mapper.Map<IssueCommentsDto>(comment));
		}

	}
}
