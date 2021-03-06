using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
	public class MenuItemsForUser : BaseSpecification<MenuItem>
	{
		public MenuItemsForUser()
		{
			AddInclude(mi => mi.Children);
		}
	}
}
