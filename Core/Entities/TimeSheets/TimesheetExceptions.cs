using System;

namespace Core.Entities.TimeSheets
{
	public class TimesheetExceptions : CoreEntity
	{
		public int timesheetId { get; set; }
		public int supervisorId { get; set; }
		public bool approved { get; set; }
		public decimal weekTime { get; set; }
		public int weekNumber { get; set; }
		public DateTime weekStart { get; set; }
		public DateTime weekEnd { get; set; }
		public String employeeComment { get; set; }
		public String comment { get; set; }

		#region External data

		public Employee Supervisor { get; set; }
		public Timesheet Timesheet { get; set; }

		#endregion

	}
}
