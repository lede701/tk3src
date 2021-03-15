using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
	public class ResultsDto
	{
		public int StatusCode { get; set; }
		public String StatusMessage { get; set; }
		public bool Success { get; set; }
	}
}
