using Core.Entities.TimeSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
	public class EmployeeSpec : BaseSpecification<Employee>
	{
		public EmployeeSpec(Expression<Func<Employee, bool>> criteria) : base(criteria)
		{
		}
	}
}
