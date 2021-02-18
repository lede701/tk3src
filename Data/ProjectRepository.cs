using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs.Timesheets;
using tk3full.Entities;
using tk3full.Interfaces;

namespace tk3full.Data
{
	public class ProjectRepository : IProjectRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public ProjectRepository(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ProjectCodeDto> AddProjectAsync(string projectTitle, string projectDesc, int commentType, int status)
		{
			// Create project object for database
			var project = new ProjectCode()
			{
				guid = Guid.NewGuid(),
				ProjectTitle = projectTitle,
				ProjectDescription = projectDesc,
				commentType = commentType,
				status = status,
				created = DateTime.Now,
				createdBy = 1,
				modified = DateTime.Now,
				modifiedBy = 1
			};
			// Add project to context
			_context.ProjectCode.Add(project);
			// Save to database
			await _context.SaveChangesAsync();

			// Return mapped results of project
			return _mapper.Map<ProjectCodeDto>(project);
		}

		public async Task<ProjectCode> FindAsync(Guid guid)
		{
			return await _context.ProjectCode
				.Where(pr => pr.guid == guid)
				.SingleOrDefaultAsync();
		}

		public async Task<ProjectCodeDto> GetProjectAsync(Guid guid)
		{
			return await _context.ProjectCode
				.Where(pr => pr.guid == guid)
				.ProjectTo<ProjectCodeDto>(_mapper.ConfigurationProvider)
				.SingleOrDefaultAsync();
				
		}

		public async Task<ProjectCodeDto> GetProjectByIdAsync(int id)
		{
			return await _context.ProjectCode
				.Where(pr => pr.id == id)
				.ProjectTo<ProjectCodeDto>(_mapper.ConfigurationProvider)
				.SingleOrDefaultAsync();
		}
	}
}
