namespace Core.Entities.TimeSheets
{
	public class DepartmentsEmployees
	{
		public int DepartmentsId { get; set; }
		public int EmpoyeesId { get; set; }

		public Departments Departments { get; set; }
		public Employee Employees { get; set; }
	}
}
