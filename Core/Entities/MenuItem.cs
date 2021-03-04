using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class MenuItem : CoreEntity
	{
		public int parentId { get; set; }
		public String name { get; set; }
		public String route { get; set; }
		public String alias { get; set; }
		public String type { get; set; }
		public DateTime published { get; set; }
		public int ordering { get; set; }
		public int checked_out { get; set; }
		public DateTime checked_out_time { get; set; }
		public bool isHome { get; set; }
		public String menuParams { get; set; }

		#region Linked Data

		#endregion
	}
}
