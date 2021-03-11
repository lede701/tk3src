using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
	public class UserListDto
	{
		public Guid guid { get; set; }
		public String userName { get; set; }
		public String firstName { get; set; }
		public String middleName { get; set; }
		public String lastName { get; set; }
		public String title { get; set; }
		public int? locationId { get; set; }
		public int? departmentId { get; set; }
		public int? workScheduleId { get; set; }
		public DateTime startDate { get; set; }
		public DateTime? terminationDate { get; set; }
		public DateTime? accuralDate { get; set; }
	}
}
