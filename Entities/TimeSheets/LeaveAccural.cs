using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class LeaveAccural
	{
		public int id { get; set; }
		public decimal earnedHours { get; set; }
		public decimal startYear { get; set; }
		public decimal endYear { get; set; }
		public decimal maxHours { get; set; }
		public int rateGroupId { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public String description { get; set; }
		public int status { get; set; }
	}
}
