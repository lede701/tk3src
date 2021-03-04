﻿using AutoMapper;
using Core.Entities;
using Core.Entities.TimeSheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IUnitOfWork
	{
		IGenericRepository<Employee> EmployeesRepository { get; }
		IGenericRepository<MenuItem> MenusRepository { get; }
		IGenericRepository<ProjectCode> ProjectsRepository { get; }
		IGenericRepository<Timesheet> TimesheetsRepository { get; }

		Task<bool> CompleteAsync();
		bool HasChanges();
		IMapper Mapper { get; }
	}
}