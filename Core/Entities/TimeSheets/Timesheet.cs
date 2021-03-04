using System;
using System.Collections.Generic;

namespace Core.Entities.TimeSheets
{
	public class Timesheet : CoreEntity
    {
		#region Table Properties

        public int employeeId { get; set; }
		public bool earlySign { get; set; }
		public String positionDescription { get; set; }
		public String firstName { get; set; }
		public String middleName { get; set; }
		public String lastname { get; set; }
		public decimal hoursPerDay { get; set; }
		public decimal hoursPerWeek { get; set; }
		public int employeeStatus { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public DateTime employeeSignDate { get; set; }
		public DateTime supervisorSignDate { get; set; }
		public String encryptKey { get; set; }
		public String employeeSignature { get; set; }
		public String supervisorSignature { get; set; }

		#endregion

		#region Linked data

		public Employee Employee { get; set; }

		public ICollection<TimesheetProjects> Projects { get; set; }
		public ICollection<TimeDetails> TimeDetails { get; set; }
		public ICollection<TimeLunch> TimeLunch { get; set; }
		public ICollection<HolidayEmployee> Holidays { get; set; }

		#endregion

	}
}
