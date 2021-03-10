using Core.Entities;
using Core.Interfaces;
using Core.Results;
using Framework.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
	public class AuthService : IAuthService
	{
		private readonly DataContext _context;

		public AuthService(DataContext context)
		{
			_context = context;
		}

		private LoginResults _results = new LoginResults { ErrorCode = -1, ErrorMessage = "", IsValid = false };
		public LoginResults Results => _results;

		public async Task<bool> Login(string username, string password)
		{
			// Validate credentails
			if (password == null || username == null)
			{
				Results.ErrorCode = 1002;
				Results.ErrorMessage = "Invalid credentials";
				return Results.IsValid;
			}

			Results.User = await _context.Users.SingleOrDefaultAsync(u => u.userName == username.ToLower());

			// Valid if user was found in database
			if (Results.User == null)
			{
				Results.ErrorCode = 1001;
				Results.ErrorMessage = "Invalid username";
				return Results.IsValid;
			}

			// Create encryption object
			using (var hmac = new HMACSHA512(Results.User.hashKey))
			{
				// Calulate password hash
				var computHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
				// Check if arrays are the same size
				if (computHash.Length != Results.User.passwordHash.Length)
				{
					Results.ErrorCode = 1004;
					Results.ErrorMessage = "Invalid password";
					return Results.IsValid;
				}
				// Compare each bit values
				for (int i = 0; i < computHash.Length; ++i)
				{
					if (computHash[i] != Results.User.passwordHash[i])
					{
						// Bit is different so this is not a valid password
						Results.ErrorCode = 1004;
						Results.ErrorMessage = "Invalid password";
						return Results.IsValid;
					}
				}
			}

			Results.IsValid = true;
			return Results.IsValid;
		}

		public async Task<PasswordHash> HashPassword(string password)
		{
			var hashed = new PasswordHash();
			using(var hmac = new HMACSHA512())
			{
				var data = Encoding.UTF8.GetBytes(password);
				MemoryStream stream = new MemoryStream();
				stream.Write(data, 0, data.Length);
				hashed.hash = await hmac.ComputeHashAsync(stream);
				hashed.key = hmac.Key;
			}

			return hashed;
		}
	}
}
