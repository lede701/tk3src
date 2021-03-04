using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Results
{
    public class LoginResults : BaseResults
    {
        public Tk3User User { get; set; }
    }
}
