﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities
{
	public class TimeLunch
	{
		#region Table Properties

		public int id { get; set; }
		[ForeignKey("Timesheet")]
		public int timesheetId { get; set; }
		public decimal lunchTime { get; set; }
		public DateTime lunchDate { get; set; }

		#endregion

		#region Linked data

		public Timesheet Timesheet { get; set; }

		#endregion
	}
}