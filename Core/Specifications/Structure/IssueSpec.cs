using Core.Entities.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Structure
{
	public  class IssueSpec : BaseSpecification<Issue>
	{
		public IssueSpec() : base()
		{
			AddInclude(i => i.IssueType);
		}
	}
}
