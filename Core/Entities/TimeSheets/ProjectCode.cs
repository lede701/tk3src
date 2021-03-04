using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.TimeSheets
{
	public class ProjectCode : CoreEntity
	{
		#region Table Parameters

		public String ProjectTitle { get; set; }
		public String ProjectDescription { get; set; }
		public int commentType { get; set; }

		#endregion

		#region Linked Data

		public ICollection<TimesheetProjects> Timesheets { get; set; }

		#endregion
	}
}
