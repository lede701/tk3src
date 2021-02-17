using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities
{
	public class TimeDetails
	{
		#region Table Properties

		public int id { get; set; }
		[ForeignKey("ProjectCode")]
		public int projectId { get; set; }
		public int timesheetId { get; set; }
		public int status { get; set; }
		public decimal hrWorked { get; set; }
		public DateTime timeDate { get; set; }

		#endregion

		#region Linked data

		public ProjectCode ProjectCode { get; set; }
		public ICollection<TimeDetailsComments> Comments { get; set; }

		#endregion
	}
}
