using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class HolidayEmployee
	{
		public int id { get; set; }
		public Guid guid { get; set; }
		public int holidayId { get; set; }
		public int timesheetId { get; set; }
		public decimal holidayHours { get; set; }
		public String comment { get; set; }

		#region Linked data

		public Timesheet Timesheet { get; set; }
		public Holidays Holiday { get; set; }

		#endregion

	}
}
