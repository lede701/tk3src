using System;

namespace Core.Entities.TimeSheets
{
	public class LeaveBank : CoreEntity
	{
		public String displayCode { get; set; }
		public String bankDescription { get; set; }
		public int expiresInDays { get; set; }
	}
}
