using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.DTOs.Timesheets
{
	public class TimeLunchDto
	{
		public Guid guid { get; set; }
		public decimal lunchTime { get; set; }
		public DateTime lunchDate { get; set; }
	}
}
