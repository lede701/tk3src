using System;

namespace Core.Entities.TimeSheets
{
	public class Signatures : CoreEntity
	{
		public int employeeId { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime lastUpdated { get; set; }
		public DateTime dateExpire { get; set; }
		public String signatureHash { get; set; }
		public bool isLocked { get; set; }

		#region Linked data

		public Employee Employee { get; set; }

		#endregion
	}
}
