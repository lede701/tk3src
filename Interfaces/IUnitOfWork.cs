using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Interfaces
{
	public interface IUnitOfWork
	{
		IUserRepository UserRepository { get; }
		IProjectRepository ProjectRepositoy { get; }
		ITimesheetRepository TimesheetRepositoy { get; }
		IMenuRepository MenuRepositoy { get; }

		IMapper Mapper { get; }

		Task<bool> Complete();
		bool HasChanges();
	}
}
