using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities
{
    public class Tk3User
    {
        public int Id{ get; set; }
        public Guid guId { get; set; }
        public String userName{ get; set; }
        public String passwordHash { get; set; }
        public String hashKey { get; set; }
        public DateTime Created { get; set; }

    }
}
