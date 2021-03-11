using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class CoreEntity
	{
		public int Id { get; set; }
		public Guid guid { get; set; }
		public Guid? OrginizationGuid { get; set; }
		public DateTime Created { get; set; }
		public int CreatedById { get; set; }
		public DateTime Modified { get; set; }
		public int ModifiedById { get; set; }
		public int StatusCode { get; set; }
	}
}
