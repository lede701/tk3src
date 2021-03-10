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

		#region Create Records [C]

		T Add(T entity);

		#endregion

		#region Read Records [R]

		Task<T> GetByGuidAsync(Guid guid);
		Task<T> GetBySpecAsync(ISpecification<T> spec);
		Task<T> GetByIdAsync(int id);
		Task<IReadOnlyCollection<T>> ListAllAsync();
		Task<IReadOnlyCollection<T>> ListAllBySpecAsync(ISpecification<T> spec);

		IQueryable<T> QueryWithSpec(ISpecification<T> spec);

		#endregion

		#region Update Records [U]

		void Update(T entity);

		#endregion

		#region Delete Records [D]

		bool MarkForDeletion(T entity);

		#endregion

	}
}
