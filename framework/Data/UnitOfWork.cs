using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities.TimeSheets;
using Core.Entities;

namespace Framework.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		//private readonly ITokenService _tokenService;

		public UnitOfWork(DataContext context, IMapper mapper/*, ITokenService tokenService*/)
		{
			_context = context;
			_mapper = mapper;
			//_tokenService = tokenService;
		}

		public async Task<bool> CompleteAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public IMapper Mapper { get { return _mapper; } }

		public IGenericRepository<Employee> EmployeesRepository => new GenericRepository<Employee>(_context);
		public IGenericRepository<LeaveTransactions> LeaveRepository => new GenericRepository<LeaveTransactions>(_context);
		public IGenericRepository<MenuItem> MenusRepository => new GenericRepository<MenuItem>(_context);
		public IGenericRepository<ProjectCode> ProjectsRepository => new GenericRepository<ProjectCode>(_context);
		public IGenericRepository<Timesheet> TimesheetsRepository => new GenericRepository<Timesheet>(_context);
		public IGenericRepository<TimeDetails> TimeDetailsRepository => new GenericRepository<TimeDetails>(_context);
		public IGenericRepository<Tk3User> UserRepository => new GenericRepository<Tk3User>(_context);

		public bool HasChanges()
		{
			return _context.ChangeTracker.HasChanges();
		}
	}
}
