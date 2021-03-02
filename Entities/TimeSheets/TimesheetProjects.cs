using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class TimesheetProjects
	{
		public int TimesheetId { get; set; }
		public int ProjectCodeId { get; set; }

		public Timesheet Timesheet { get; set; }
		public ProjectCode ProjectCode { get; set; }
	}
}
