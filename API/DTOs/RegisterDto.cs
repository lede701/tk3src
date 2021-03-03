using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
	public class RegisterDto
	{
		[Required]
		public String LoginName { get; set; }
		[Required]
		public String Password { get; set; }
		[Required]
		public String Confirm { get; set; }
	}
}
