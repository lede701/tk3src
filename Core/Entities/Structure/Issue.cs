using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Structure
{
	public class Issue : CoreEntity
	{
		public String IssueTitle { get; set; }
		public String IssueDescription { get; set; }
		public int Severity { get; set; }
		public IssueType IssueType { get; set; }

		public ICollection<IssueComments> Comments { get; set; } = new List<IssueComments>();
	}
}
