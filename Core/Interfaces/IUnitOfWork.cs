using AutoMapper;
using Core.Entities;
using Core.Entities.Structure;
using Core.Entities.TimeSheets;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IUnitOfWork
	{
		IGenericRepository<Employee> EmployeesRepository { get; }
		IGenericRepository<LeaveTransactions> LeaveRepository { get; }
		IGenericRepository<MenuItem> MenusRepository { get; }
		IGenericRepository<ProjectCode> ProjectsRepository { get; }
		IGenericRepository<Timesheet> TimesheetsRepository { get; }
		IGenericRepository<TimeDetails> TimeDetailsRepository { get; }
		IGenericRepository<Tk3User> UserRepository { get; }
		IGenericRepository<CoreOrginizationEntity> OrginizationRepository { get; }
		IGenericRepository<Issue> IssueRepository { get; }

		Task<bool> CompleteAsync();
		bool HasChanges();
		IMapper Mapper { get; }
	}
}
