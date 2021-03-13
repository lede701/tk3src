using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Structure
{
	public class IssueCommentsDto
	{
		public Guid guid { get; set; }
		public String Comment { get; set; }
		public int Rating { get; set; }
	}
}
