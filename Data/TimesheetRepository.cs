using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs.Timesheets;
using tk3full.Entities;
using tk3full.Interfaces;

namespace tk3full.Data
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TimesheetRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TimesheetDto> GetTimesheet(Guid guid)
        {
            return await _context.Timesheet
                .Where(ts => ts.guid == guid)
                .ProjectTo<TimesheetDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<TimesheetDto> CreateTimesheet(Tk3User user)
        {
            // Create new timesheet
            Timesheet ts = new Timesheet()
            {
                userId = user.Id,
                guid = Guid.NewGuid(),
                firstName = user.firstName,
                middleName = user.middleName,
                lastname = user.lastName,
                positionDescription = user.title,
                hoursPerWeekWorked = user.workHoursPerWeek
            };
            // Add new timesheet to the contrxt
            _context.Timesheet.Add(ts);
            // Process database query
            await _context.SaveChangesAsync();
            // Returned mapped DTO obecjt
            return _mapper.Map<TimesheetDto>(ts);
        }
    }
}
