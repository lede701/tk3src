using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class Signatures
	{
		public int Id { get; set; }
		public Guid guid { get; set; }
		public int userId { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime lastUpdated { get; set; }
		public DateTime dateExpire { get; set; }
		public String signatureHash { get; set; }
		public bool isLocked { get; set; }
		public int status { get; set; }

		#region Linked data

		public Tk3User User { get; set; }

		#endregion
	}
}
