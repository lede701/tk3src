using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.TimeSheets
{
	public class TimeDetails : CoreEntity
	{
		#region Table Properties

		[ForeignKey("ProjectCode")]
		public int projectId { get; set; }
		public int timesheetId { get; set; }
		public decimal hrWorked { get; set; }
		public DateTime timeDate { get; set; }

		#endregion

		#region Linked data

		public ProjectCode ProjectCode { get; set; }
		public ICollection<TimeDetailsComments> Comments { get; set; } = new List<TimeDetailsComments>();

		#endregion
	}
}
