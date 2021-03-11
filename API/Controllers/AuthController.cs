using API.DTOs;
using API.Extensions;
using Core.Entities;
using Core.Entities.TimeSheets;
using Core.Interfaces;
using Core.Specifications;
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

        [HttpPost("create")]
        public async Task<ActionResult<UserDto>> Create(RegisterDto user)
        {
            if (user.Password != user.Confirm) return BadRequest("ERROR: Passwords match they do not!");

            var pw = _auth.HashPassword(user.Password);

            Employee newUser = new Employee()
            {
                firstName = user.FirstName,
                lastName = user.LastName,
                middleName = user.MiddleName,
                userName = user.UserName,
                passwordHash = pw.hash,
                hashKey = pw.key,
                accuralDate = DateTime.Now,
                startDate = DateTime.Now,
                title = "",
                locationId = 1,
                departmentId = 1,
                workScheduleId = 1
            };

            // Add user to system            
            newUser = _uow.EmployeesRepository.Add(newUser);
            // Store changes to database
            await _uow.CompleteAsync();

            if (newUser is Tk3User)
            {
                // Convert Tk3User to Dto object
                var userDto = _uow.Mapper.Map<UserDto>(newUser);
                userDto.Token = await _tokenService.CreateTokenAsync(newUser);
                userDto.tokenExpires = DateTime.UtcNow.AddMinutes(_tokenExpiresInMinutes);
                return Ok(userDto);
            }

            return BadRequest("ERROR: User create it has not!");
        }

        [HttpPost("reset")]
        public async Task<ActionResult<UserDto>> ResetPassword(PasswordResetDto pw)
        {
            // Check if current password is correct
            var user = await _uow.EmployeesRepository.GetByGuidAsync(Guid.Parse(User.GetUserId()));
            if (await _auth.Login(user.userName, pw.OriginalPassword) && pw.Password == pw.ConfirmPassword)
            {
                // Create the hash password
                var pwHash = _auth.HashPassword(pw.Password);
                user.passwordHash = pwHash.hash;
                user.hashKey = pwHash.key;
                // Set entity for updating
                _uow.EmployeesRepository.Update(user);
                await _uow.CompleteAsync();

                // Return proper results
                return Ok(_uow.Mapper.Map<UserDto>(user));
            }

            // Error occured in the change password process
            return BadRequest("ERROR: Password reset failed to complete it did.");
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
        [HttpGet("userlist")]
        public async Task<ActionResult<IReadOnlyCollection<UserListDto>>> UserList()
		{
            var user = await _uow.UserRepository.GetByGuidAsync(Guid.Parse(User.GetUserId()));
            var list = await _uow.EmployeesRepository.ListAllBySpecAsync(new EmployeeSpec(e => e.OrginizationGuid == user.OrginizationGuid));
            if (list?.Count > 0) return Ok(_uow.Mapper.Map<IReadOnlyCollection<UserListDto>>(list));

            return BadRequest("ERROR: There are no users to list.");
		}
    }
}
