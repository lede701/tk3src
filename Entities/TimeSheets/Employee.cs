using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class Employee
	{
		#region Employee Parameters

		public int Id { get; set; }
		// Remving guid because it mayne redundant and make things more confusing
//		public Guid guid { get; set; }
		public int userId { get; set; }
		public int? locationId { get; set; }
//		[ForeignKey("PrimaryDepartment")]
		public int? departmentId { get; set; }
		public int? workScheduleId { get; set; }
		public DateTime startDate { get; set; }
		public DateTime? teminationDate { get; set; }
		public DateTime? accuralDate { get; set; }
		public DateTime created { get; set; }
		public int createdById { get; set; }
		public DateTime modified { get; set; }
		public int modifiedById { get; set; }

		#endregion

		#region External Data
		public Tk3User User { get; set; }

		public ICollection<DepartmentsEmployees> Departments { get; set; } = new List<DepartmentsEmployees>();
		//public Locations Location { get; set; }
		//public Departments PrimaryDepartment { get; set; }
		//public WorkSchedule WorkSchedule { get; set; }
		//public Tk3User createdBy { get; set; }
		//public Tk3User modifiedBy { get; set; }

		#endregion

	}
}
