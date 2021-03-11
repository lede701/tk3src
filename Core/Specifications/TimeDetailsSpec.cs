using Core.Entities.TimeSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
	public class TimeDetailsSpec : BaseSpecification<TimeDetails>
	{

		public TimeDetailsSpec(Guid guid) : base(td => td.guid == guid)
		{
			AddInclude(td => td.Comments);
			AddInclude(td => td.ProjectCode);
		}

		public TimeDetailsSpec(int tsid) : base(td => td.timesheetId == tsid)
		{
			AddInclude(td => td.Comments);
			AddInclude(td => td.ProjectCode);
		}
		public TimeDetailsSpec(Expression<Func<TimeDetails, bool>> criteria) : base(criteria)
		{
		}
	}
}
