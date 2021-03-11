using API.DTOs;
using AutoMapper;
using Core.Entities;
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

		public MenuController(IUnitOfWork uow)
		{
			_uow = uow;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenu()
		{
			
			var items = await _uow.MenusRepository.ListAllBySpecAsync(new MenuItemsForUserSpec());
			return Ok(_uow.Mapper.Map<IReadOnlyCollection<MenuItemDto>>(items));
		}

		[HttpPost("create")]
		public async Task<ActionResult<MenuItemDto>> Create([FromForm]MenuItemDto item)
        {
			// Map DTO to MenuItem object
			var newItem = _uow.Mapper.Map<MenuItem>(item);
			// Check if guid is empty
			if (item.guid == Guid.Empty)
            {
				// Add menu item to repository
				_uow.MenusRepository.Add(newItem);
			}
			else
			{
				//TODO: Merge changes from DTO to entity
				/*
				var dbItem = await _uow.MenusRepository.GetByGuidAsync(item.guid);
				var noUpdate = ["Created", "CreatedById", "guid"];
				foreach(var pi in typeof(MenuItem).GetProperties())
				{
					var fieldName = pi.Name;
					var newVal = pi.GetGetMethod().Invoke(newItem, null);
					var dbVal = pi.GetGetMethod().Invoke(dbItem, null);
				}
				//*/
			}

			// Save changes
			await _uow.CompleteAsync();

			// Return results of MenuItem being created or updated
			return Ok(_uow.Mapper.Map<MenuItemDto>(newItem));
        }

		[HttpGet("updatemenu")]
		public async Task<ActionResult<String>> UpdateMenu()
		{

			return Ok("Menu update it was.");
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMyMenu(String username)
		{
			//return Ok(await _uow.MenuRepositoy.GetMenuItemsAsync(User.GetUsername()));

			return BadRequest("ERROR: Feature implamented it is not.");
		}

		[HttpGet("get/{guid}")]
		public async Task<ActionResult<MenuItemDto>> GetMenuItem(String guid)
		{
			var item = await _uow.MenusRepository.GetByGuidAsync(Guid.Parse(guid));
			if (item != null) return Ok(_uow.Mapper.Map<MenuItemDto>(item));

			return BadRequest("ERROR: Menu item found it was not!");
		}

		[HttpPost("store")]
		public async Task<ActionResult<MenuItemDto>> Store(MenuItemDto item)
		{
			var mItem = _uow.Mapper.Map<MenuItem>(item);
			if(item.guid == Guid.Empty)
			{
				_uow.MenusRepository.Add(mItem);
			}
			else
			{
				_uow.MenusRepository.Update(mItem);
			}

			await _uow.CompleteAsync();

			return Ok(item);
		}
	}
}
