using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities.TimeSheets
{
	public class Locations
	{
		public int Id { get; set; }
		public Guid guid { get; set; }
		public int? parentId { get; set; }
		public String locationCity { get; set; }
		public String locationState { get; set; }
		public int status { get; set; }
	}
}
