using API.DTOs;
using AutoMapper;
using Core.Interfaces;
using Core.Specifications;
using Framework.Data;
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
			
			var items = await _uow.MenusRepository.ListAllBySpecAsync(new MenuItemsForUserSpec());
			return Ok(_mapper.Map<IReadOnlyCollection<MenuItemDto>>(items));
		}

		[HttpGet("updatemenu")]
		public async Task<ActionResult<String>> UpdateMenu()
		{
			// Try and load the timesheet menu item
			var tsItem = await _uow.MenusRepository.GetByIdAsync(2);
			tsItem.Children.Add(new Core.Entities.MenuItem
			{
				guid = Guid.NewGuid(),
				name = "Sheet View",
				route = "/timesheet",
				type = "mainmenu",
				published = DateTime.Now,
				ordering = 200,
				isHome = false,
				Created = DateTime.Now,
				CreatedById = 1,
				Modified = DateTime.Now,
				ModifiedById = 1,
				StatusCode = RecordStatus.ACTIVE
			});

			await _uow.CompleteAsync();

			return Ok("Menu update it was.");
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
