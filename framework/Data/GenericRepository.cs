using Core.Entities;
using Core.Interfaces;
using Framework.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Data
{
	public class GenericRepository<T> : IGenericRepository<T> where T: CoreEntity
	{
		private readonly DataContext _context;

		public GenericRepository(DataContext context)
		{
			_context = context;
		}

		public T Add(T entity)
		{
			entity.guid = Guid.NewGuid();
			entity.Created = DateTime.Now;
			entity.CreatedById = 1;
			entity.Modified = DateTime.Now;
			entity.StatusCode = RecordStatus.ACTIVE;

			_context.Set<T>().Add(entity);
			return entity;
		}

		public async Task<T> GetByGuidAsync(Guid guid)
		{
			return await _context.Set<T>()
				.Where(item => item.guid == guid && item.StatusCode == RecordStatus.ACTIVE)
				.FirstOrDefaultAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<IReadOnlyCollection<T>> ListAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public Task<IReadOnlyCollection<T>> ListAllByUserAsync(int userId)
		{
			throw new NotImplementedException();
		}

		public bool MarkForDeletion(T entity)
		{
			entity.StatusCode = RecordStatus.DELETED;
			entity.Modified = DateTime.Now;
			entity.ModifiedById = 1;

			_context.Set<T>().Update(entity);
			return true;
		}

		public void Update(T entity)
		{
			entity.Modified = DateTime.Now;
			entity.ModifiedById = 1;

			_context.Set<T>().Update(entity);
		}
	}
}
