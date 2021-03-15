using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Structure
{
	public class IssueCommentVotes
	{
		public Guid UserGuid { get; set; }
		public Guid CommentGuid { get; set; }
		public int Vote { get; set; }
	}
}
