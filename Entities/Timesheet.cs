using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities
{
    public class Timesheet
    {
		#region Table Properties

		public int id { get; set; }
        public int userId { get; set; }
		public bool earlySign { get; set; }
		public String positionDescription { get; set; }
		public String firstName { get; set; }
		public String middleName { get; set; }
		public String lastname { get; set; }
		public decimal workHours { get; set; }
		public decimal hoursPerWeekWorked { get; set; }
		public int employeeStatus { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public DateTime employeeSignDate { get; set; }
		public DateTime supervisorSignDate { get; set; }
		public String encryptKey { get; set; }
		public String employeeSignature { get; set; }
		public String supervisorSignature { get; set; }

		#endregion

		#region Linked data
		public Tk3User User { get; set; }

		public ICollection<TimeDetails> TimeDetails { get; set; }
		public ICollection<TimeLunch> TimeLunch { get; set; }

		#endregion

	}
}
