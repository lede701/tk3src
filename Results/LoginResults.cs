using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs;
using tk3full.Entities;

namespace tk3full.Results
{
    public class LoginResults : BaseResults
    {
        public Tk3User User { get; set; }
        public UserDto userDto { get; set; }
    }
}
