using Core.Entities;
using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IAuthService
	{
		Task<bool> Login(String userName, String password);
		LoginResults Results { get; }
		Task<PasswordHash> HashPassword(String password);
	}
}
