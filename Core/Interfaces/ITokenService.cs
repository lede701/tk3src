using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface ITokenService
	{
		Task<String> CreateTokenAsync(Tk3User user);
		Task<bool> RevokeTokenAsync(Tk3User user);
	}
}
