using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs;

namespace tk3full.Interfaces
{
	public interface IMenuRepository
	{
		Task<IEnumerable<MenuItemDto>> GetMenuItemsAsync(String username);
	}
}
