using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.DTOs.Timesheets
{
    public class TimesheetDto
    {
		public Guid guid { get; set; }
		public bool earlySign { get; set; }
		public String positionDescription { get; set; }
		public String firstName { get; set; }
		public String middleName { get; set; }
		public String lastname { get; set; }
		public decimal workHours { get; set; }
		public decimal hoursPerWeekWorked { get; set; }
		public int employeeStatus { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public DateTime employeeSignDate { get; set; }
		public DateTime supervisorSignDate { get; set; }

		public ICollection<TimeDetailsDto> TimeDetails { get; set; }

	}
}
