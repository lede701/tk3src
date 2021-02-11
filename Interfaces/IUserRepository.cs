using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs;
using tk3full.Entities;

namespace tk3full.Interfaces
{
	public interface IUserRepository
	{
		void Update(Tk3User user);
		Task<bool> SaveAllAsync();
		Task<IEnumerable<Tk3User>> GetUsersAsync();
		Task<Tk3User> GetUserByIdAsync(int id);
		Task<Tk3User> GetUserByUsernameAsync(String username);
		Task<UserDto> GetUserDtoByUserNameAsync(String username);
	}
}
