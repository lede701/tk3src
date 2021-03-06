using API.DTOs;
using API.Extensions;
using Core.Entities;
using Core.Interfaces;
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

namespace API.Controllers
{
    public class AuthController : CoreController
    {
		private readonly IUnitOfWork _uow;
		private readonly ITokenService _tokenService;
		private readonly IAuthService _auth;
		private int _tokenExpiresInMinutes;

        public AuthController(IUnitOfWork uow, ITokenService tokenService, IConfiguration config, IAuthService auth)
        {
			_uow = uow;
			_tokenService = tokenService;
			_auth = auth;
			_tokenExpiresInMinutes = Convert.ToInt32(config["TokenAgeInMinutes"]);
        }

        [HttpGet("reset/{guid}")]
        public async Task<ActionResult<UserDto>> ResetUser(String guid)
        {

            var user = await _uow.EmployeesRepository.GetByGuidAsync(Guid.Parse(guid));

            using var hmac = new HMACSHA512();
            user.passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("test1234"));
            user.hashKey = hmac.Key;

            _uow.EmployeesRepository.Update(user);
            await _uow.CompleteAsync();

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
            var user = await _uow.EmployeesRepository.GetByGuidAsync(Guid.Parse(User.GetUserId()));
            //var user = await _uow.UserRepository.GetUserByGuidAsync(Guid.Parse(User.GetUserId()));
            // Return user name
            return Ok(new WhoAmIDto { 
                Name = String.Format("{0} {1}", user.firstName, user.lastName),
                Username = user.userName
            });
		}

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
		{
            if (!await _auth.Login(login.UserName, login.Password)) return BadRequest(_auth.Results);

            var user = _auth.Results.User;

            var userDto = _uow.Mapper.Map<UserDto>(user);
            userDto.Token = await _tokenService.CreateTokenAsync(user);
            userDto.tokenExpires = DateTime.UtcNow.AddMinutes(_tokenExpiresInMinutes);

            return Ok(userDto);
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
		{
            String guid = User.GetUserId();
            if (guid == null) return Ok("Token passed it was not.");
            var user = await _uow.EmployeesRepository.GetByGuidAsync(Guid.Parse(guid));
            if (user != null) return Ok();
//            if (await _uow.UserRepository.LogoutAsync(user)) return Ok();

            return BadRequest("ERROR: Could not log user out of system");
		}

        [HttpPost("tokenupdate")]
        public ActionResult<UserDto> TokenUpdate(string guid)
		{
            /*
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
            */
            return BadRequest("Implamented token update is not.");
		}
    }
}
