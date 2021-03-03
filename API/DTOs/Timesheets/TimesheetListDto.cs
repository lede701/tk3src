using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Timesheets
{
	public class TimesheetListDto
	{
		public Guid guid { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
	}
}
