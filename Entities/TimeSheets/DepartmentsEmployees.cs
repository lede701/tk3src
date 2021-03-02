using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class DepartmentsEmployees
	{
		public int DepartmentsId { get; set; }
		public int EmpoyeesId { get; set; }

		public Departments Departments { get; set; }
		public Employee Employees { get; set; }
	}
}
