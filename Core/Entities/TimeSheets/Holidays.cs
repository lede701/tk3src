using System;

namespace Core.Entities.TimeSheets
{
	public class Holidays : CoreEntity
	{
		public int locationId { get; set; }
		public DateTime holidayDate { get; set; }
		public String holidayDescription { get; set; }
	}
}
