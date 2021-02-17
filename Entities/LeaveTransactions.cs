using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities
{
	public class LeaveTransactions
	{
		#region Table Properties

		public int id { get; set; }
		[ForeignKey("User")]
		public int userId { get; set; }
		public int parentId { get; set; }
		public int locationId { get; set; }
		[ForeignKey("Bank")]
		public int bankId { get; set; }
		public char tranType { get; set; }
		public decimal tranTime { get; set; }
		public DateTime tranDate { get; set; }
		public DateTime created { get; set; }
		public DateTime modified { get; set; }
		public DateTime displayDate { get; set; }
		public bool employeeSigned { get; set; }
		public bool approved { get; set; }
		public bool isAccrual { get; set; }
		public bool isParent { get; set; }
		public int status { get; set; }

		#endregion

		#region Linked Data

		public Tk3User User { get; set; }
		public LeaveBank Bank { get; set; }

		#endregion

	}
}
