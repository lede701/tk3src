using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using tk3full.Entities.TimeSheets;

namespace tk3full.Entities
{
    public class Tk3User
    {
        public int Id{ get; set; }
		public int forignId { get; set; }
		public Guid guId { get; set; }
        public String userName{ get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] hashKey { get; set; }
		public String firstName { get; set; }
		public String middleName { get; set; }
		public String lastName { get; set; }
		public String title { get; set; }


		public DateTime created { get; set; }
		public DateTime modified { get; set; }
		public String userParams { get; set; }
		public int status { get; set; }

	}
}
