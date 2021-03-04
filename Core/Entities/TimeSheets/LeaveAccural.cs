using System;

namespace Core.Entities.TimeSheets
{
	public class LeaveAccural : CoreEntity
	{
		public decimal earnedHours { get; set; }
		public decimal startYear { get; set; }
		public decimal endYear { get; set; }
		public decimal maxHours { get; set; }
		public int rateGroupId { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public String description { get; set; }
	}
}
