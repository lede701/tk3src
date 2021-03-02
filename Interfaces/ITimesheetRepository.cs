using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs.Timesheets;
using tk3full.Entities;
using tk3full.Entities.TimeSheets;

namespace tk3full.Interfaces
{
    public interface ITimesheetRepository
    {
        Task<Timesheet> FindAsync(Guid guid);
        Task<TimesheetDto> CreateTimesheetAsync(Employee emp, DateTime start, DateTime end);
        Task<TimeLunchDto> AddLunchAsync(Timesheet ts, decimal time, DateTime day);
        Task AddCommentAsync(TimeDetails tdo, String comment);
        Task AddTimeAsync(TimeDetails td, Timesheet ts);

        Task<TimeDetails> GetDetails(Guid guid);
        Task<TimesheetDto> GetTimesheetDtoAsync(Guid guid);
        Task<ICollection<TimesheetListDto>> GetTimesheetListAsync(Employee emp);
        Task<TimesheetDto> GetTimesheetWithIdAsync(int id);
    }
}
