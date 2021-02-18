using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs.Timesheets;
using tk3full.Interfaces;

namespace tk3full.Controllers
{
	public class ProejctController : Tk3BaseController
	{
		private readonly IProjectRepository _projectRepo;
		private readonly IMapper _mapper;

		public ProejctController(IProjectRepository projectRepo, IMapper mapper)
		{
			_projectRepo = projectRepo;
			_mapper = mapper;
		}

		[HttpPost("add")]
		public async Task<ActionResult<ProjectCodeDto>> AddProject(String projectTitle, String projectDesc, int commentType)
		{
			ProjectCodeDto project = await _projectRepo.AddProjectAsync(projectTitle, projectDesc, commentType, RecordStatus.ACTIVE);
			if (project != null) return Ok(project);

			return BadRequest("ERROR: Project was not added!");
		}
	}
}
