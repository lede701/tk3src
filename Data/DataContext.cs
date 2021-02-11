﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tk3full.Entities;

namespace tk3full.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Tk3User> Users { get; set; }
		public DbSet<Timesheet> Timesheet { get; set; }
		public DbSet<MenuItem> Menu { get; set; }
	}}