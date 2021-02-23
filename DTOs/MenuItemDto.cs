using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.DTOs
{
	public class MenuItemDto
	{
		public String name { get; set; }
		public String route { get; set; }
		public String alias { get; set; }

		public ICollection<MenuItemDto> children { get; set; }
	}
}
