using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs;
using tk3full.Entities;
using tk3full.Results;

namespace tk3full.Interfaces
{
	public interface IUserRepository
	{
		void Update(Tk3User user);
		Task<IEnumerable<Tk3User>> GetUsersAsync();
		Task<Tk3User> FindAsync(int id);
		Task<Tk3User> GetUserByUsernameAsync(String username);
		Task<Tk3User> GetUserByGuidAsync(Guid guid);
		Task<UserDto> GetUserDtoByUserNameAsync(String username);
		Task<LoginResults> LoginAsync(String username, String password);
		Task<bool> LogoutAsync(Tk3User user);
	}
}
