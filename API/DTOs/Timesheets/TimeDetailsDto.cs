﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Timesheets
{
    public class TimeDetailsDto
    {
		public Guid guid { get; set; }
		public int status { get; set; }
		public decimal hrWorked { get; set; }
		public DateTime timeDate { get; set; }

		public ProjectCodeDto ProjectCode { get; set; }
		public ICollection<TimeDetailsCommentsDto> Comments { get; set; }

	}
}
