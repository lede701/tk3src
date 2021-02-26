using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class WorkSchedule
	{
		public int id { get; set; }
		public Guid guid { get; set; }
		public String title { get; set; }
		public decimal hoursPerDay { get; set; }
		public decimal hoursPerWeek { get; set; }
		public decimal hoursPerHoliday { get; set; }
	}
}
