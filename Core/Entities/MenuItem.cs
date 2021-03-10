using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class MenuItem : CoreEntity
	{
		public int parentId { get; set; } = 0;
		public String name { get; set; }
		public String route { get; set; }
		public String alias { get; set; } = "";
		public String type { get; set; } = "mainmenu";
		public DateTime published { get; set; } = DateTime.Now;
		public int ordering { get; set; }
		public int checked_out { get; set; } = 0;
		public DateTime checked_out_time { get; set; } = DateTime.MinValue;
		public bool isHome { get; set; } = false;
		public String menuParams { get; set; } = "";

		#region Linked Data

		public ICollection<MenuItem> Children { get; set; } = new List<MenuItem>();

		#endregion
	}
}
