using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
	public class ApiException : ApiResponse
	{
		public String Details { get; set; }
		public ApiException(int statusCode, String message = null, String details = null) : base(statusCode, message)
		{
			Details = details ?? String.Empty;
		}

	}
}
