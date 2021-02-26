using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class TimesheetExceptions
	{
		public int id { get; set; }
		public Guid guid { get; set; }
		public int timesheetId { get; set; }
		public int supervisorId { get; set; }
		public bool approved { get; set; }
		public decimal weekTime { get; set; }
		public int weekNumber { get; set; }
		public DateTime weekStart { get; set; }
		public DateTime weekEnd { get; set; }
		public DateTime created { get; set; }
		public DateTime modified { get; set; }
		public int status { get; set; }
		public String employeeComment { get; set; }
		public String comment { get; set; }

		#region External data

		public Tk3User Supervisor { get; set; }
		public Timesheet Timesheet { get; set; }

		#endregion

	}
}
