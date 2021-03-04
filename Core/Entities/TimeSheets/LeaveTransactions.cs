using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.TimeSheets
{
	public class LeaveTransactions : CoreEntity
	{
		#region Table Properties

		[ForeignKey("Employee")]
		public int employeeId { get; set; }
		public int parentId { get; set; }
		public int locationId { get; set; }
		[ForeignKey("Bank")]
		public int bankId { get; set; }
		public char tranType { get; set; }
		public decimal tranTime { get; set; }
		public DateTime tranDate { get; set; }
		public DateTime displayDate { get; set; }
		public bool employeeSigned { get; set; }
		public bool approved { get; set; }
		public bool isAccrual { get; set; }
		public bool isParent { get; set; }

		#endregion

		#region Linked Data

		public Employee Employee{ get; set; }
		public LeaveBank Bank { get; set; }

		#endregion

	}
}
