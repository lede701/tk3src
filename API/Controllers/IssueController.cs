using API.DTOs;
using API.DTOs.Structure;
using API.Extensions;
using Core.Entities.Structure;
using Core.Interfaces;
using Core.Specifications.Structure;
using Framework.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class IssueController : CoreController
	{
		private readonly IUnitOfWork _uow;
		private readonly DataContext _ctx;

		public IssueController(IUnitOfWork uow, DataContext ctx)
		{
			_uow = uow;
			_ctx = ctx;
		}

		[HttpGet("list")]
		public async Task<ActionResult<IReadOnlyCollection<IssueDto>>> List()
		{
			var list = await _uow.IssueRepository.ListAllBySpecAsync(new IssueSpec());
			return Ok(_uow.Mapper.Map<IReadOnlyCollection<IssueDto>>(list));
		}

		[HttpGet("typelist")]
		public async Task<ActionResult<IReadOnlyCollection<IssueTypeDto>>> IssueTypeList()
		{
			var list = await _ctx.IssueTypes.Where(it => it.StatusCode == RecordStatus.ACTIVE).ToListAsync();
			return Ok(_uow.Mapper.Map<IReadOnlyCollection<IssueTypeDto>>(list));
		}

		[HttpGet("get/{guid}")]
		public async Task<ActionResult<IssueDto>> GetIssue(String guid)
        {
			var issue = await _uow.IssueRepository.GetBySpecAsync(new IssueSpec(Guid.Parse(guid)));
			if (issue != null) return Ok(_uow.Mapper.Map<IssueDto>(issue));

			return BadRequest("ERROR: Issue found it was not.");
        }

		[HttpPost("store")]
		public async Task<ActionResult<ResultsDto>> StoreIssue(IssueDto issueDto)
		{
			var issue = new Issue();
			if(issueDto.guid != Guid.Empty)
			{
				issue = await _uow.IssueRepository.GetBySpecAsync(new IssueSpec(issueDto.guid));
			}
			issue.IssueTitle = issueDto.IssueTitle;
			issue.IssueDescription = issueDto.IssueDescription;
			issue.IssueType = await _ctx.IssueTypes.Where(it => it.guid == issueDto.IssueType.guid).FirstOrDefaultAsync();
			issue.Severity = issueDto.Severity;
			if(issueDto.guid == Guid.Empty){
				_uow.IssueRepository.Add(issue);
			}
			else
			{
				_uow.IssueRepository.Update(issue);
			}
			var results = new ResultsDto()
			{
				Success = false,
				StatusCode = 500,
				StatusMessage = "Issue was not save."
			};

			if(await _uow.CompleteAsync())
			{
				results.Success = true;
				results.StatusCode = 200;
				results.StatusMessage = "Issue was stored in system.";
			}
			
			return Ok(results);
		}

		#region Issue Comments

		[HttpPost("comment/add/{guid}")]
		public async Task<ActionResult<IssueCommentsDto>> AddComment(String guid, IssueCommentsDto comment)
		{
			var issueGuid = Guid.Parse(guid);
			var issue = await _uow.IssueRepository.GetByGuidAsync(issueGuid);
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
					ModifiedById = user.Id,
					StatusCode = RecordStatus.ACTIVE
				});
			}

			_uow.IssueRepository.Update(issue);
			await _uow.CompleteAsync();
			return Ok(_uow.Mapper.Map<IssueCommentsDto>(issue.Comments.Last()));
				
		}

		[HttpGet("comment/get/{guid}")]
		public async Task<ActionResult<IssueCommentsDto>> GetComment(String guid)
		{
			var comment = new IssueComments()
			{
				guid = Guid.Parse(guid)
			};

			comment = await _uow.IssueCommentRepository.GetByGuidAsync(comment.guid);

			return Ok(_uow.Mapper.Map<IssueCommentsDto>(comment));
		}

		[HttpGet("comment/up")]
		public async Task<ActionResult<IssueCommentsDto>> CommentUp(String guid)
		{
			var cmntGuid = Guid.Parse(guid);
			var voted = await _ctx.IssueCommentVotes.Where(v => v.CommentGuid == cmntGuid && v.UserGuid == User.GetUserId()).FirstOrDefaultAsync();
			if (voted != null) return BadRequest("ERROR: Already voted you have.");
			// Load comment from database
			var comment = await _uow.IssueCommentRepository.GetByGuidAsync(cmntGuid);

			// Check if we have a valid comment
			if (comment == null) return BadRequest("ERROR: Comment updated it was not.");
			// Update rating
			comment.Rating++;
			var vote =new IssueCommentVotes()
			{
				CommentGuid = cmntGuid,
				UserGuid = User.GetUserId(),
				Vote = 1
			};
			_ctx.IssueCommentVotes.Add(vote);

			// Tell entiry framework the recrod was updaetd
			_uow.IssueCommentRepository.Update(comment);
			await _uow.CompleteAsync();

			return Ok(_uow.Mapper.Map<IssueCommentsDto>(comment));

		}

		[HttpGet("comment/down")]
		public async Task<ActionResult<IssueCommentsDto>> CommentDown(String guid)
		{
			var cmntGuid = Guid.Parse(guid);
			var voted = await _ctx.IssueCommentVotes.Where(v => v.CommentGuid == cmntGuid && v.UserGuid == User.GetUserId()).FirstOrDefaultAsync();
			if (voted != null) return BadRequest("ERROR: Already voted you have.");
			// Load comment from database
			var comment = await _uow.IssueCommentRepository.GetByGuidAsync(cmntGuid);

			// Check if we have a valid comment
			if (comment == null) return BadRequest("ERROR: Comment updated it was not.");
			// Update rating
			comment.Rating--;
			var vote = new IssueCommentVotes()
			{
				CommentGuid = cmntGuid,
				UserGuid = User.GetUserId(),
				Vote = -1
			};
			_ctx.IssueCommentVotes.Add(vote);
			_uow.IssueCommentRepository.Update(comment);
			// Tell entiry framework the recrod was updaetd
			_uow.IssueCommentRepository.Update(comment);
			await _uow.CompleteAsync();

			return Ok(_uow.Mapper.Map<IssueCommentsDto>(comment));
		}

		#endregion

	}
}
