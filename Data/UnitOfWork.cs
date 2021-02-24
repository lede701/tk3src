using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.Interfaces;

namespace tk3full.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		private readonly ITokenService _tokenService;

		public UnitOfWork(DataContext context, IMapper mapper, ITokenService tokenService)
		{
			_context = context;
			_mapper = mapper;
			_tokenService = tokenService;
		}

		public IUserRepository UserRepository => new UserRepository(_context, _mapper, _tokenService);

		public IProjectRepository ProjectRepositoy => new ProjectRepository(_context, _mapper);

		public ITimesheetRepository TimesheetRepositoy => new TimesheetRepository(_context, _mapper);

		public IMenuRepository MenuRepositoy => new MenuRepository(_context, _mapper);

		public async Task<bool> Complete()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public IMapper Mapper { get { return _mapper; } }

		public bool HasChanges()
		{
			return _context.ChangeTracker.HasChanges();
		}
	}
}
