using API.DTOs;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	public class MenuController : CoreController
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public MenuController(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenu()
		{
			var items = await _uow.MenusRepository.ListAllAsync();
			return Ok(_mapper.Map<IReadOnlyCollection<MenuItemDto>>(items));
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMyMenu(String username)
		{
			//return Ok(await _uow.MenuRepositoy.GetMenuItemsAsync(User.GetUsername()));

			return BadRequest("ERROR: Feature implamented it is not.");
		}
	}
}
