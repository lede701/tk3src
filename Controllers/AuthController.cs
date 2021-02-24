﻿using Microsoft.AspNetCore.Http;
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
using tk3full.Extensions;
using tk3full.Interfaces;
using tk3full.Results;

namespace tk3full.Controllers
{
    public class AuthController : Tk3BaseController
    {
		private readonly IUnitOfWork _uow;
		private readonly ITokenService _tokenService;

        public AuthController(IUnitOfWork uow, ITokenService tokenService)
        {
			_uow = uow;
			_tokenService = tokenService;
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
        public ActionResult<WhoAmIDto> WhoAmI()
		{
            return Ok(new WhoAmIDto { Username = User.GetUsername() });
		}

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
		{
            LoginResults results = await _uow.UserRepository.LoginAsync(login.UserName, login.Password);
            if (results.IsValid)
            {
                results.userDto.Token = await _tokenService.CreateTokenAsync(results.User);
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
    }
}
