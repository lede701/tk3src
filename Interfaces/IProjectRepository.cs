using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using tk3full.DTOs.Timesheets;
using tk3full.Entities;

namespace tk3full.Interfaces
{
	public interface IProjectRepository
	{
		Task<ProjectCode> FindAsync(Guid guid);
		Task<ProjectCodeDto> GetProjectAsync(Guid guid);
		Task<ProjectCodeDto> GetProjectByIdAsync(int id);
		Task<ProjectCodeDto> AddProjectAsync(String projectTitle, String projectDesc, int commentType, int status);
	}
}
