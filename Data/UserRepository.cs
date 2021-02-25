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
using System.Security.Cryptography;
using System.Text;
using tk3full.Results;

namespace tk3full.Data
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserRepository(DataContext context, IMapper mapper, ITokenService tokenService)
		{
			_context = context;
			_mapper = mapper;
            _tokenService = tokenService;
        }

		public async Task<Tk3User> FindAsync(int id)
		{
			return await _context
				.Users
				.FindAsync(id);
		}

		public async Task<Tk3User> GetUserByGuidAsync(Guid guid)
		{
			return await _context
				.Users
				.SingleOrDefaultAsync(u => u.guId == guid);
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

        public async Task<LoginResults> LoginAsync(string username, string password)
        {
			// Create initial login results and try and get user from database
			LoginResults results = new LoginResults()
			{
				ErrorCode = -1,
				ErrorMessage = "",
				IsValid = false,
			};

			// Validate credentails
			if (password == null || username == null)
			{
				results.ErrorCode = 1002;
				results.ErrorMessage = "Invalid credentials";
				return results;
			}

			results.User = await _context.Users.SingleOrDefaultAsync(u => u.userName == username.ToLower());

			// Valid if user was found in database
			if (results.User == null)
            {
				results.ErrorCode = 1001;
				results.ErrorMessage = "Invalid username";
				return results;
            }

			// Create encryption object
			using (var hmac = new HMACSHA512(results.User.hashKey))
			{
				// Calulate password hash
				var computHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
				// Check if arrays are the same size
				if(computHash.Length != results.User.passwordHash.Length)
                {
					results.ErrorCode = 1003;
					results.ErrorMessage = "Invalid password";
					return results;
				}
				for (int i = 0; i < computHash.Length; ++i)
				{
					if (computHash[i] != results.User.passwordHash[i])
					{
						results.ErrorCode = 1004;
						results.ErrorMessage = "Invalid password";
						return results;
					}
				}
			}

			results.IsValid = true;
			results.userDto = _mapper.Map<UserDto>(results.User);
			return results;
		}

		public async Task<bool> LogoutAsync(Tk3User user)
		{
			return await _tokenService.RevokeTokenAsync(user);
		}

		public void Update(Tk3User user)
		{
			_context.Entry(user).State = EntityState.Modified;
		}
	}
}
