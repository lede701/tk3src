using API.DTOs.Timesheets;
using AutoMapper;
using Core.Entities.TimeSheets;
using Core.Interfaces;
using Framework.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class ProejctController : CoreController
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public ProejctController(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
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
			if (project != null) return Ok(_mapper.Map<ProjectCodeDto>(project));

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
	}
}
