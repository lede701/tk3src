using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs;
using tk3full.Interfaces;

namespace tk3full.Data
{
	public class MenuRepository : IMenuRepository
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public MenuRepository(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<MenuItemDto>> GetMenuItemsAsync(string username)
		{
			return await _context.Menu.
				ProjectTo<MenuItemDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
		}
	}
}
