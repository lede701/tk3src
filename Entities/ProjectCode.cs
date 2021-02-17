using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities
{
	public class ProjectCode
	{
		#region Table Parameters

		public int id { get; set; }
		public String ProjectTitle { get; set; }
		public String ProjectDescription { get; set; }
		public int commentType { get; set; }
		public int status { get; set; }
		public DateTime created { get; set; }
		[ForeignKey("CreatedUser")]
		public int createdBy { get; set; }
		public DateTime modified { get; set; }
		[ForeignKey("ModifiedUser")]
		public int modifiedBy { get; set; }

		#endregion

		#region Linked Data

		public Tk3User CreatedUser { get; set; }
		public Tk3User ModifiedUser { get; set; }

		#endregion
	}
}
