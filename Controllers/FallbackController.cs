using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Controllers
{
	public class FallbackController : Controller
	{
		public FallbackController()
		{
			/**
			 * Tools -> Options
			 * Text Editor -> C# -> Code Style -> Naming
			 * Manage naming styles
			 * 
			 * [+] -> _fieldName
			 * Required Prefix: _
			 * Capitalization: camelCaseName
			 * Ok
			 * 
			 * [+] Add specification
			 * Secification: Private or internal Field
			 * Require Style: _fieldName
			 * Servity: Suggestion
			 * 
			//*/
		}

		public ActionResult Index()
		{
			return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/HTML");
		}
	}
}
