using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.DTOs.Timesheets
{
	public class ProjectCodeDto
	{
		public Guid guid { get; set; }
		public String ProjectTitle { get; set; }
		public String ProjectDescription { get; set; }
		public int commentType { get; set; }
		public int status { get; set; }
	}
}
