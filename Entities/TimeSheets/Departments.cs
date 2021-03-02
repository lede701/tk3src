using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class Departments
	{
		public int Id { get; set; }
		public Guid guid { get; set; }
		public String name { get; set; }
		public String departmentCode { get; set; }
		public int status { get; set; }
		public String deptParams { get; set; }

		public ICollection<DepartmentsEmployees> Employees { get; set; }
	}
}
