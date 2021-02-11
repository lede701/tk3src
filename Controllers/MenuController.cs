using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.Data;
using tk3full.DTOs;
using tk3full.Interfaces;

namespace tk3full.Controllers
{
	public class MenuController : Tk3BaseController
	{
		private readonly IMenuRepository _menuRepo;

		public MenuController(IMenuRepository menuRepo)
		{
			_menuRepo = menuRepo;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenu()
		{
			return Ok(await _menuRepo.GetMenuItemsAsync("undefined"));
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMyMenu(String username)
		{
			return Ok(await _menuRepo.GetMenuItemsAsync("undefined"));
		}
	}
}
