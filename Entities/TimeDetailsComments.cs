using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities
{
	public class TimeDetailsComments
	{
		#region Table Properties

		public int id { get; set; }
		[ForeignKey("TimeDetails")]
		public int timeDetailsId { get; set; }
		[ForeignKey("Timesheet")]
		public int timesheetId { get; set; }
		public int status { get; set; }
		public String comment { get; set; }
		public DateTime created { get; set; }
		public DateTime modified { get; set; }

		#endregion

		#region Linked Data

		public TimeDetails TimeDetails { get; set; }
		public Timesheet Timesheet { get; set; }

		#endregion

	}
}
