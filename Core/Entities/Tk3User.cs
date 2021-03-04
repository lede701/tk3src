using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.TimeSheets;

namespace Core.Entities
{
    public class Tk3User : CoreEntity
    {
		public int forignId { get; set; }
        public String userName{ get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] hashKey { get; set; }
		public String firstName { get; set; }
		public String middleName { get; set; }
		public String lastName { get; set; }
	}
}
