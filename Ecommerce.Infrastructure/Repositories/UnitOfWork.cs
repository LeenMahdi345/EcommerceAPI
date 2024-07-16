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
	public class UnitOfWork<T> : IUnitOfWork<T> where T : class
	{
		public UnitOfWork(AppDbContext DbContext) {
			this.DbContext = DbContext;
			productRepository=new ProductRepository(DbContext);
		}
		public IProductRepositories productRepository { get; set; }
		public AppDbContext DbContext { get; }
		public IOrdersRepositories OrdersRepository { get ; set ; }

		public int Save()
		{
		return DbContext.SaveChanges();
		}
	}

}
