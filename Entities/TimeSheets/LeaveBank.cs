using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class LeaveBank
	{
		public int Id { get; set; }
		public Guid guid { get; set; }
		public String displayCode { get; set; }
		public String bankDescription { get; set; }
		public int expiresInDays { get; set; }
		public int status { get; set; }
	}
}
