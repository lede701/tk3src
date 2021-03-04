using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.TimeSheets
{
	public class TimeLunch : CoreEntity
	{
		#region Table Properties

		[ForeignKey("Timesheet")]
		public int timesheetId { get; set; }
		public decimal lunchTime { get; set; }
		public DateTime lunchDate { get; set; }

		#endregion

		#region Linked data

		public Timesheet Timesheet { get; set; }

		#endregion
	}
}
