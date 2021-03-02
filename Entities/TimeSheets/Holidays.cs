using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class Holidays
	{
		public int Id { get; set; }
		public Guid guid { get; set; }
		public int locationId { get; set; }
		public DateTime holidayDate { get; set; }
		public String holidayDescription { get; set; }
	}
}
