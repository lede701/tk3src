namespace Core.Entities.TimeSheets
{
	public class TimesheetProjects
	{
		public int TimesheetId { get; set; }
		public int ProjectCodeId { get; set; }

		public Timesheet Timesheet { get; set; }
		public ProjectCode ProjectCode { get; set; }
	}
}
