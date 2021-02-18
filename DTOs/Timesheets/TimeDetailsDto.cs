using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.DTOs.Timesheets
{
    public class TimeDetailsDto
    {
		public int id { get; set; }
		public int projectId { get; set; }
		public int timesheetId { get; set; }
		public int status { get; set; }
		public decimal hrWorked { get; set; }
		public DateTime timeDate { get; set; }
	}
}
