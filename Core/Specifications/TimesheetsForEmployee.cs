using Core.Entities.TimeSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
	public class TimesheetsForEmployee : BaseSpecification<Timesheet>
	{
		public TimesheetsForEmployee(TimesheetSpecParams specs) : base(ts => ts.employeeId == specs.Employee.Id)
		{
			// Add data to load with the timesheet
			AddInclude(ts => ts.Employee);
			AddInclude(ts => ts.TimeDetails);
			AddInclude(ts => ts.TimeLunch);

			AddOrderBy(ts => ts.startDate);

			if(!String.IsNullOrEmpty(specs.Sort))
			{
				switch (specs.Sort)
				{
					case "endDate":
						AddOrderBy(ts => ts.endDate);
						break;
				}
			}
		}

		public TimesheetsForEmployee(int EmployeeId) : base(ts => ts.employeeId == EmployeeId)
		{
			AddInclude(ts => ts.Employee);
			AddInclude(ts => ts.TimeDetails);
			AddInclude(ts => ts.TimeLunch);

			AddOrderBy(ts => ts.startDate);
		}
	}
}
