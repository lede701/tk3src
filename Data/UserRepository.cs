using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using tk3full.DTOs;
using tk3full.Entities;
using tk3full.Interfaces;

namespace tk3full.Data
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public UserRepository(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Tk3User> GetUserByIdAsync(int id)
		{
			return await _context
				.Users
				.FindAsync(id);
		}

		public async Task<Tk3User> GetUserByUsernameAsync(string username)
		{
			return await _context
				.Users
				.SingleOrDefaultAsync(u => u.userName == username.ToLower());
		}

		public async Task<UserDto> GetUserDtoByUserNameAsync(string username)
		{
			return await _context.Users
				.Where(u => u.userName == username)
				.ProjectTo<UserDto>(_mapper.ConfigurationProvider)
				.SingleOrDefaultAsync();
		}

		public async Task<IEnumerable<Tk3User>> GetUsersAsync()
		{
			return await _context
				.Users
				.ToListAsync();
		}

		public async Task<bool> SaveAllAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public void Update(Tk3User user)
		{
			_context.Entry(user).State = EntityState.Modified;
		}
	}
}
