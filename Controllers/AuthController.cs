using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using tk3full.Data;
using tk3full.DTOs;
using tk3full.Entities;
using tk3full.Interfaces;

namespace tk3full.Controllers
{
    public class AuthController : Tk3BaseController
    {
        private readonly DataContext _context;
		private readonly IUserRepository _userRepo;
		private readonly ITokenService _tokenService;

		public AuthController(DataContext context, IUserRepository userRepo, ITokenService tokenService)
        {
            _context = context;
			_userRepo = userRepo;
			_tokenService = tokenService;
		}

        [HttpGet]
        public async Task<ActionResult<UserDto>> Index()
        {
            var user = await _context.Users.FindAsync(1);

            using var hmac = new HMACSHA512();
            user.passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("test1234"));
            user.hashKey = hmac.Key;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                UserName = user.userName,
                Token = "Need to make token"
            };
        }

        [HttpPost("LoginDto")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
		{
            Tk3User user = await _context.Users.SingleOrDefaultAsync(u => u.userName == login.UserName.ToLower());
            if (user == null) return Unauthorized("Invalid username");
            using (var hmac = new HMACSHA512(user.hashKey))
            {
                var computHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
                for (int i = 0; i < computHash.Length; ++i)
                {
                    if (computHash[i] != user.passwordHash[i]) return Unauthorized("Invalid Password");
                }
            }
            return new UserDto
            {
                UserName = user.userName,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}
