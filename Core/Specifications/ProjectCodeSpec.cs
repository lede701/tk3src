using Core.Entities.TimeSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
	public class ProjectCodeSpec : BaseSpecification<ProjectCode>
	{
		public ProjectCodeSpec()
		{
			AddOrderBy(pc => pc.ProjectTitle);
		}
		public ProjectCodeSpec(Expression<Func<ProjectCode, bool>> criteria) : base(criteria)
		{
			AddOrderBy(pc => pc.ProjectTitle);
		}
	}
}
