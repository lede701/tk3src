using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
	public class ApiResponse
	{
		public int StatusCode { get; set; }
		public String Message { get; set; }
		public ApiResponse(int statusCode, string message=null)
		{
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
		}

		public String GetDefaultMessageForStatusCode(int statusCode)
		{
			return statusCode switch
			{
				400 => "Bad request, you have made.",
				401 => "Authorizewd, you're not!",
				404 => "Resource found, it was not.",
				500 => "Errors are the path to the dark side!",
				_ => String.Empty
			};
		}
	}
}
