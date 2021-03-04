using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IGenericRepository<T> where T: CoreEntity
	{
		T Add(T entity);
		Task<T> GetByGuidAsync(Guid guid);
		Task<T> GetByIdAsync(int id);
		Task<IReadOnlyCollection<T>> ListAllAsync();
		Task<IReadOnlyCollection<T>> ListAllByUserAsync(int userId);

		bool MarkForDeletion(T entity);
		void Update(T entity);

	}
}
