using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
	public class RegisterDto
	{
		public String FirstName { get; set; }
		public String MiddleName { get; set; }
		public String LastName { get; set; }
		public String email { get; set; }
		[Required]
		public String UserName { get; set; }
		[Required]
		public String Password { get; set; }
		[Required]
		public String Confirm { get; set; }
	}
}
