using Core.Entities.TimeSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
	public class EmployeeSpecParams
	{
		private const int MaxRecodsSize = 30;
		public int PageIndex { get; set; } = 1;
		private int _pageSize = MaxRecodsSize;
		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxRecodsSize) ? MaxRecodsSize : value;
		}

		public Employee Employee { get; set; }
		public String Sort { get; set; } = "";
	}
}
