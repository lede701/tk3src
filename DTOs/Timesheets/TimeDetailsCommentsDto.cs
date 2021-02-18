using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.DTOs.Timesheets
{
	public class TimeDetailsCommentsDto
	{
		public Guid guid { get; set; }
		public int status { get; set; }
		public String comment { get; set; }
	}
}
