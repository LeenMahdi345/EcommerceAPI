using Ecommerce.Core.Entites;
using Ecommerce.Core.IReositories;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly AppDbContext dbContext;

		public GenericRepository(AppDbContext dbContext)

		{
			this.dbContext = dbContext;
		}
		public async Task Create(T model)

		{
			if (typeof(T) == typeof(Products))
			{
				dbContext.Set<T>().AddAsync(model);
			}
		}

		public void Delete(int id)
		{
			dbContext.Remove(id);
		}

		public async Task<IEnumerable<T>> GetAllOrders(int userId)
		{
			if (typeof(T) == typeof(Orders))
			{
				var model = await dbContext.Orders.Include(x => x.LocalUser).ToListAsync();

				return (IEnumerable<T>)model;

			}
			return await dbContext.Set<T>().ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			if (typeof(T) == typeof(Products))
			{
				var model = await dbContext.Products.Include(x => x.category).ToListAsync();

				return (IEnumerable<T>)model;

			}
			return await dbContext.Set<T>().ToListAsync();
		}

		public  async Task<T> GetById(int id)
		{
			return await dbContext.Set<T>().FindAsync(id);
		}

		public void Update(T model)
		{
			 dbContext.Set<T>().Update(model);
		}
	}
}
