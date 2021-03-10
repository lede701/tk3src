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
		private readonly DbSet<T> _dbSet;

		public GenericRepository(DataContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public T Add(T entity)
		{
			entity.guid = Guid.NewGuid();
			entity.Created = DateTime.Now;
			entity.CreatedById = 1;
			entity.Modified = DateTime.Now;
			entity.StatusCode = RecordStatus.ACTIVE;

			_dbSet.Add(entity);
			return entity;
		}

		public async Task<T> GetByGuidAsync(Guid guid)
		{
			return await _dbSet
				.Where(item => item.guid == guid && item.StatusCode == RecordStatus.ACTIVE)
				.FirstOrDefaultAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public async Task<T> GetBySpecAsync(ISpecification<T> spec)
		{
			var query = ApplySpecification(spec);
			return await query.FirstOrDefaultAsync();
		}

		public async Task<IReadOnlyCollection<T>> ListAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<IReadOnlyCollection<T>> ListAllBySpecAsync(ISpecification<T> spec)
		{
			// Create query with privded specification
			var query = ApplySpecification(spec);
			return await query.ToListAsync();
		}

		public bool MarkForDeletion(T entity)
		{
			entity.StatusCode = RecordStatus.DELETED;
			entity.Modified = DateTime.Now;
			entity.ModifiedById = 1;

			_dbSet.Update(entity);
			return true;
		}

		public IQueryable<T> QueryWithSpec(ISpecification<T> spec)
		{
			return ApplySpecification(spec);
		}

		public void Update(T entity)
		{
			entity.Modified = DateTime.Now;
			entity.ModifiedById = 1;

			_dbSet.Update(entity);
		}

		private IQueryable<T> ApplySpecification(ISpecification<T> spec)
		{
			return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
		}
	}
}
