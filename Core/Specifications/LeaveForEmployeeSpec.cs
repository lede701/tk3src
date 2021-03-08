using Core.Entities.TimeSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
	public class LeaveForEmployeeSpec : BaseSpecification<LeaveTransactions>
	{
		public LeaveForEmployeeSpec(EmployeeSpecParams specs) : base(lv => lv.employeeId == specs.Employee.Id)
		{
			AddInclude(lv => lv.Bank);
			AddInclude(lv => lv.Employee);
		}
		public LeaveForEmployeeSpec(int employeeId) : base(lv => lv.employeeId == employeeId)
		{
			AddInclude(lv => lv.Employee);
			AddInclude(lv => lv.Bank);

			AddOrderByDesc(lv => lv.tranDate);
			AddOrderBy(lv => lv.Bank.displayCode);
		}
	}
}
