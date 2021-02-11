using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities
{
	public class MenuItem
	{
		public int Id { get; set; }
		public int parentId { get; set; }
		public String name { get; set; }
		public String link { get; set; }
		public String alias { get; set; }
		public String type { get; set; }
		public DateTime published { get; set; }
		public int ordering { get; set; }
		public int checked_out { get; set; }
		public DateTime checked_out_time { get; set; }
		public bool isHome { get; set; }
		public String menuParams { get; set; }
		public DateTime created { get; set; }
		public int createdBy { get; set; }
		public DateTime modified { get; set; }
		public int modifiedBy { get; set; }
		public int status { get; set; }
	}
}
