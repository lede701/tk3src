using System;

namespace Core.Entities.TimeSheets
{
	public class WorkSchedule : CoreEntity
	{
		public String title { get; set; }
		public decimal hoursPerDay { get; set; }
		public decimal hoursPerWeek { get; set; }
		public decimal hoursPerHoliday { get; set; }
	}
}
