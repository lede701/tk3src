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
        Task<Timesheet> FindAsync(Guid guid);
        Task<TimesheetDto> CreateTimesheetAsync(Tk3User user, DateTime start, DateTime end);
        Task<bool> AddTimeAsync(TimeDetails td, Timesheet ts);
        Task<bool> AddCommentAsync(TimeDetails tdo, String comment);

        Task<TimeDetails> GetDetails(Guid guid);
        Task<TimesheetDto> GetTimesheetDtoAsync(Guid guid);
        Task<TimesheetDto> GetTimesheetWithIdAsync(int id);
    }
}
