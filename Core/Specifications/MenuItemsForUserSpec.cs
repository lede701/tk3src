using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
	public class MenuItemsForUserSpec : BaseSpecification<MenuItem>
	{
		public MenuItemsForUserSpec()
		{
			AddInclude(mi => mi.Children);
			AddOrderBy(mi => mi.ordering);
		}
	}
}
