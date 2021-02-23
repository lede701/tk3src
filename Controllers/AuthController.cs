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
using tk3full.Results;

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

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
		{
            LoginResults results = await _userRepo.LoginAsync(login.UserName, login.Password);
            if (results.IsValid)
            {
                results.userDto.Token = _tokenService.CreateToken(results.User);
                return Ok(results.userDto);
            }

            return BadRequest(String.Format("{0}: {1}", results.ErrorCode, results.ErrorMessage));
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
		{

            return BadRequest("ERROR: Could not log user out of system");
		}
    }
}
