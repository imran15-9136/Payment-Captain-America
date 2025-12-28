using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.SharedKernel.Interface
{
	public interface IRepository
	{
		Task AddAsync<T>(T entity) where T : class;
		Task<T> GetByIdAsync<T>(Guid id) where T : class;
		Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
		Task UpdateAsync<T>(T entity) where T : class;
		Task DeleteAsync<T>(T entity) where T : class;
	}
}
