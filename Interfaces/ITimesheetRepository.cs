using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs.Timesheets;
using tk3full.Entities;

namespace tk3full.Interfaces
{
    public interface ITimesheetRepository
    {
        Task<TimesheetDto> GetTimesheet(Guid guid);
        Task<TimesheetDto> CreateTimesheet(Tk3User user);
    }
}
