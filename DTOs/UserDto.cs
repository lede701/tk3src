﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.DTOs
{
    public class UserDto
    {
        public String UserName { get; set; }
        public String Token { get; set; }
		public DateTime tokenExpires { get; set; }
	}
}
