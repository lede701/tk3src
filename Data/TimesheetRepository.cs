using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.DTOs.Timesheets;
using tk3full.Entities;
using tk3full.Entities.TimeSheets;
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

        public async Task AddCommentAsync(TimeDetails td, String commentIn)
		{
            TimeDetailsComments tdc = new TimeDetailsComments()
            {
                guid = Guid.NewGuid(),
                timesheetId = td.timesheetId,
                comment = commentIn,
                created = DateTime.Now,
                modified = DateTime.Now,
                status = RecordStatus.ACTIVE
            };
            td.Comments.Add(tdc);
            await _context.TimeDetailsComments.AddAsync(tdc);
		}

        public async Task<TimeLunchDto> AddLunchAsync(Timesheet ts, decimal time, DateTime day)
        {
            TimeLunch tl = new TimeLunch
            {
                guid = Guid.NewGuid(),
                timesheetId = ts.id,
                lunchTime = time,
                lunchDate = day
            };
            await _context.TimeLunch.AddAsync(tl);
            return _mapper.Map<TimeLunchDto>(tl);
        }


        public async Task AddTimeAsync(TimeDetails td, Timesheet ts)
        {
            td.timesheetId = ts.id;
            await _context.TimeDetails.AddAsync(td);
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
                hoursPerWeek = 40.0m,
                hoursPerDay = 8.0m,
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
            return await _context
                .Timesheet
                .Where(ts => ts.id == id)
                .ProjectTo<TimesheetDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
		}

		public async Task<TimeDetails> GetDetails(Guid guid)
		{
            return await _context.TimeDetails.Where(td => td.guid == guid)
                .SingleOrDefaultAsync();
		}

		public async Task<ICollection<TimesheetListDto>> GetTimesheetListAsync(Tk3User user)
		{
            return await _context.Timesheet
                .Where(ts => ts.userId == user.Id)
                .ProjectTo<TimesheetListDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
		}
	}
}
