using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.TimeSheets
{
	public class TimeDetailsComments : CoreEntity
	{
		#region Table Properties

		[ForeignKey("TimeDetails")]
		public int timeDetailsId { get; set; }
		[ForeignKey("Timesheet")]
		public int timesheetId { get; set; }
		public String Comment { get; set; }

		#endregion

		#region Linked Data

		public TimeDetails TimeDetails { get; set; }
		public Timesheet Timesheet { get; set; }

		#endregion

	}
}
