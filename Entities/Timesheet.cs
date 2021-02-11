using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tk3full.Entities
{
    public class Timesheet
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public Tk3User User { get; set; }
        public decimal HoursPerWeekWorked { get; set; }

    }
}
