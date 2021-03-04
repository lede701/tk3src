using System;
using System.Collections.Generic;

namespace Core.Entities.TimeSheets
{
	public class Departments : CoreEntity
	{
		public String name { get; set; }
		public String departmentCode { get; set; }
		public String deptParams { get; set; }

		public ICollection<DepartmentsEmployees> Employees { get; set; }
	}
}
