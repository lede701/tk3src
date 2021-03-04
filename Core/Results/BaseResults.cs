using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Results
{
    public class BaseResults
    {
        public int ErrorCode { get; set; }
        public String ErrorMessage { get; set; }
        public bool IsValid { get; set; }


    }
}
