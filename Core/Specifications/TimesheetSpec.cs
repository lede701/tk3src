using Core.Entities.TimeSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
	public class TimesheetSpec : BaseSpecification<Timesheet>
	{
		public TimesheetSpec(int id) : base(ts => ts.Id == id)
		{
			SetupSheet();
		}

		public TimesheetSpec(Guid guid) : base(ts => ts.guid == guid)
		{
			SetupSheet();
		}

		private void SetupSheet()
		{
			AddInclude(ts => ts.TimeDetails);
			AddInclude(ts => ts.TimeLunch);
			AddInclude(ts => ts.Holidays);
		}
	}
}
