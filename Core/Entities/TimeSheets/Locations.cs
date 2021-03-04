using System;

namespace Core.Entities.TimeSheets
{
	public class Locations : CoreEntity
	{
		public int? parentId { get; set; }
		public String locationCity { get; set; }
		public String locationState { get; set; }
	}
}
