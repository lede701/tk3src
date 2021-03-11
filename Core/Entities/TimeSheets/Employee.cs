using System;
using System.Collections.Generic;

namespace Core.Entities.TimeSheets
{
	public class Employee : Tk3User
	{
		#region Employee Parameters

		public String title { get; set; }
		public int? locationId { get; set; }
//		[ForeignKey("PrimaryDepartment")]
		public int? departmentId { get; set; }
		public int? workScheduleId { get; set; }
		public DateTime startDate { get; set; }
		public DateTime? terminationDate { get; set; }
		public DateTime? accuralDate { get; set; }

		#endregion

		#region External Data

		public ICollection<DepartmentsEmployees> Departments { get; set; } = new List<DepartmentsEmployees>();
		//public Locations Location { get; set; }
		//public Departments PrimaryDepartment { get; set; }
		//public WorkSchedule WorkSchedule { get; set; }
		//public Tk3User createdBy { get; set; }
		//public Tk3User modifiedBy { get; set; }

		#endregion

	}
}
