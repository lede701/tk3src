using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Structure
{
	public class IssueComments : CoreEntity
	{
		public String Comment { get; set; }
		public int Rating { get; set; }
	}
}
