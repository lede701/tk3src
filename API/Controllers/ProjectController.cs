using API.DTOs.Timesheets;
using AutoMapper;
using Core.Entities.TimeSheets;
using Core.Interfaces;
using Core.Specifications;
using Framework.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class ProjectController : CoreController
	{
		private readonly IUnitOfWork _uow;

		public ProjectController(IUnitOfWork uow)
		{
			_uow = uow;
		}
		[HttpGet("get/{guid}")]
		public async Task<ActionResult<ProjectCodeDto>> Get(String guid)
		{
			var project = await _uow.ProjectsRepository.GetByGuidAsync(Guid.Parse(guid));
			if (project != null) return Ok(_uow.Mapper.Map<ProjectCodeDto>(project));

			return BadRequest("ERROR: Project code found it was not.");
		}

		//[Authorize]
		[HttpGet("adminlist")]
		public async Task<ActionResult<IReadOnlyCollection<ProjectCodeDto>>> AdminList()
		{
			var list = await _uow.ProjectsRepository.ListAllBySpecAsync(new ProjectCodeSpec());
			if (list != null) return Ok(_uow.Mapper.Map<IReadOnlyCollection<ProjectCodeDto>>(list));

			return BadRequest("ERROR: Project list found it was not.");
		}

		[HttpPost("create")]
		public async Task<ActionResult<ProjectCodeDto>> CreateProject(String projectTitle, String projectDesc, int commentType)
		{
			// Create new project in data center
			var project = _uow.ProjectsRepository.Add(new ProjectCode
			{
				ProjectTitle = projectTitle,
				ProjectDescription = projectDesc,
				commentType = commentType,
			});
			// Complete project creation process
			await _uow.CompleteAsync();
			// Return mapped DTO object
			if (project != null) return Ok(_uow.Mapper.Map<ProjectCodeDto>(project));

			// Something really strange happened so send a failed request message
			return BadRequest("ERROR: Project was not added!");
		}

		[HttpPost("delete")]
		public async Task<ActionResult<ProjectCodeDto>> DeleteProject(string guid)
		{
			var project = await _uow.ProjectsRepository.GetByGuidAsync(Guid.Parse(guid));
			// Check for invalid project
			if (project == null) BadRequest("ERROR: Project, not found was it.");

			// Tell system to delete project
			_uow.ProjectsRepository.MarkForDeletion(project);
			if (await _uow.CompleteAsync()) return Ok("Deleted project was.");

			return BadRequest("ERROR: Deleted, project was not!");
		}

		[HttpPost("store")]
		public async Task<ActionResult<ProjectCodeDto>> Store(ProjectCodeDto project)
		{
			if(project.guid == Guid.Empty)
			{
				_uow.ProjectsRepository.Add(new ProjectCode { 
					ProjectTitle = project.ProjectTitle,
					ProjectDescription = project.ProjectDescription,
					commentType = project.commentType
				});
			}
			else
			{
				var dbProject = await _uow.ProjectsRepository.GetByGuidAsync(project.guid);
				dbProject.ProjectTitle = project.ProjectTitle;
				dbProject.ProjectDescription = project.ProjectDescription;
				dbProject.commentType = project.commentType;
				_uow.ProjectsRepository.Update(dbProject);
			}

			await _uow.CompleteAsync();
			return Ok(project);
		}
	}
}
