using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Timesheets
{
	public class LeaveTransactionDto
	{
		public Guid guid { get; set; }
		public char tranType { get; set; }
		public decimal tranTime { get; set; }
		public DateTime tranDate { get; set; }
		public DateTime displayDate { get; set; }
		public bool employeeSigned { get; set; }
		public bool approved { get; set; }
		public bool isAccrual { get; set; }
		public String BankName { get; set; }
		public String BankCode { get; set; }
	}
}
