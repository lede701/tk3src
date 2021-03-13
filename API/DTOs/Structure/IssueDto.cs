using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Structure
{
	public class IssueDto
	{
		public Guid guid { get; set; }
		public String IssueTitle { get; set; }
		public String IssueDescription { get; set; }
		public int Severity { get; set; }
		public IssueTypeDto IssueType { get; set; }
	}
}
