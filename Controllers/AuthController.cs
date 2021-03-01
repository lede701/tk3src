using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using tk3full.Data;
using tk3full.DTOs;
using tk3full.Entities;
using tk3full.Extensions;
using tk3full.Interfaces;
using tk3full.Results;

namespace tk3full.Controllers
{
    public class AuthController : Tk3BaseController
    {
		private readonly IUnitOfWork _uow;
		private readonly ITokenService _tokenService;
        private int _tokenExpiresInMinutes;

        public AuthController(IUnitOfWork uow, ITokenService tokenService, IConfiguration config)
        {
			_uow = uow;
			_tokenService = tokenService;
            _tokenExpiresInMinutes = Convert.ToInt32(config["TokenAgeInMinutes"]);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> Index()
        {
            var user = await _uow.UserRepository.FindAsync(1);

            using var hmac = new HMACSHA512();
            user.passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("test1234"));
            user.hashKey = hmac.Key;

            _uow.UserRepository.Update(user);
            await _uow.Complete();

            return new UserDto
            {
                UserName = user.userName,
                Token = "Need to make token"
            };
        }

        [HttpGet("whoami")]
        public async Task<ActionResult<WhoAmIDto>> WhoAmI()
		{
            // Load user infromation
            Tk3User user = await _uow.UserRepository.GetUserByGuidAsync(Guid.Parse(User.GetUserId()));
            // Return user name
            return Ok(new WhoAmIDto { 
                Name = String.Format("{0} {1}", user.firstName, user.lastName),
                Username = user.userName
            });
		}

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
		{
            LoginResults results = await _uow.UserRepository.LoginAsync(login.UserName, login.Password);
            if (results.IsValid)
            {
                results.userDto.Token = await _tokenService.CreateTokenAsync(results.User);
                results.userDto.tokenExpires = DateTime.UtcNow.AddMinutes(_tokenExpiresInMinutes);
                return Ok(results.userDto);
            }

            return BadRequest(String.Format("{0}: {1}", results.ErrorCode, results.ErrorMessage));
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
		{
            String username = User.GetUsername();
            if (username == null) return Ok("User token not passed");
            var user = await _uow.UserRepository.GetUserByUsernameAsync(username);
            if (await _uow.UserRepository.LogoutAsync(user)) return Ok();
            return BadRequest("ERROR: Could not log user out of system");
		}

        [HttpPost("tokenupdate")]
        public async Task<ActionResult<UserDto>> TokenUpdate(string guid)
		{
            // Load user recrod
            Tk3User user = await _uow.UserRepository.GetUserByGuidAsync(Guid.Parse(guid));
            // Validate we have a valid user
            if(user != null)
			{
                // Create user dto
                UserDto userDto = _uow.Mapper.Map<UserDto>(user);
                // Create new token
                userDto.Token = await _tokenService.CreateTokenAsync(user);
                userDto.tokenExpires = DateTime.UtcNow.AddMinutes(120);
                return Ok(userDto);
            }
            return BadRequest("User can not update token at this time");
		}
    }
}
