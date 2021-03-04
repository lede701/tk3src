using Core.Entities.TimeSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
	public class TimesheetSpecParams
	{
		private const int MaxSheetSize = 30;
		public int SheetIndex { get; set; } = 1;
		private int _sheetSize = MaxSheetSize;
		public int SheetSize
		{
			get => _sheetSize;
			set => _sheetSize = (value > MaxSheetSize) ? MaxSheetSize : value;
		}

		public Employee Employee { get; set; }
		public String Sort { get; set; } = "startDate";
	}
}
