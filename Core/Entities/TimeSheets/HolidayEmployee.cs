using System;

namespace Core.Entities.TimeSheets
{
	public class HolidayEmployee : CoreEntity
	{
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
