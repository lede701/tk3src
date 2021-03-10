using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class PasswordHash
	{
		public byte[] hash { get; set; }
		public byte[] key { get; set; }
	}
}
