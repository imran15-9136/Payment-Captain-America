using PaymentService.SharedKernel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Infrastructure.Implementation
{
	public class Repository : IRepository
	{
		public Task AddAsync<T>(T entity) where T : class
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync<T>(T entity) where T : class
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<T>> GetAllAsync<T>() where T : class
		{
			throw new NotImplementedException();
		}

		public Task<T> GetByIdAsync<T>(Guid id) where T : class
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync<T>(T entity) where T : class
		{
			throw new NotImplementedException();
		}
	}
}
