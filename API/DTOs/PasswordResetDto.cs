using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class PasswordResetDto
    {
        public String OriginalPassword { get; set; }
        public String Password { get; set; }
        public String ConfirmPassword { get; set; }
    }
}
