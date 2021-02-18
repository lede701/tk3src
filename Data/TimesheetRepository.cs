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

        public async Task<bool> AddCommentAsync(TimeDetails td, String commentIn)
		{
            TimeDetailsComments tdc = new TimeDetailsComments()
            {
                guid = Guid.NewGuid(),
                timesheetId = td.timesheetId,
                timeDetailsId = td.id,
                comment = commentIn,
                created = DateTime.Now,
                modified = DateTime.Now,
                status = RecordStatus.ACTIVE
            };
            _context.TimeDetailsComments.Add(tdc);
            return await _context.SaveChangesAsync() > 0;
		}

        public async Task<bool> AddTimeAsync(TimeDetails td, Timesheet ts)
        {
            td.timesheetId = ts.id;
            _context.TimeDetails.Add(td);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<Timesheet> FindAsync(Guid guid)
        {
            return await _context.Timesheet
                .Where(ts => ts.guid == guid)
                .SingleOrDefaultAsync();
        }

        public async Task<TimesheetDto> GetTimesheetDtoAsync(Guid guid)
        {
            return await _context.Timesheet
                .Where(ts => ts.guid == guid)
                .ProjectTo<TimesheetDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<TimesheetDto> CreateTimesheetAsync(Tk3User user, DateTime start, DateTime end)
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
                hoursPerWeek = user.workHoursPerWeek,
                startDate = start,
                endDate = end
            };
            // Add new timesheet to the contrxt
            _context.Timesheet.Add(ts);
            // Process database query
            await _context.SaveChangesAsync();
            // Returned mapped DTO obecjt
            return _mapper.Map<TimesheetDto>(ts);
        }

		public async Task<TimesheetDto> GetTimesheetWithIdAsync(int id)
		{
            var ts = await _context.Timesheet.FindAsync(id);
            if(ts.guid == new Guid("00000000-0000-0000-0000-000000000000"))
			{
                ts.guid = Guid.NewGuid();
                _context.Timesheet.Update(ts);
                await _context.SaveChangesAsync();
			}

            return _mapper.Map<TimesheetDto>(ts);
		}

		public async Task<TimeDetails> GetDetails(Guid guid)
		{
            return await _context.TimeDetails.Where(td => td.guid == guid)
                .SingleOrDefaultAsync();
		}
	}
}
