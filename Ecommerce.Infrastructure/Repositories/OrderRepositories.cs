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
	public class OrderRepositories :GenericRepository<Orders>, IOrdersRepositories
	{
		private readonly AppDbContext dbContext;
	

	public OrderRepositories(AppDbContext dbContext) : base(dbContext)
	{
		this.dbContext = dbContext;

	}
	

		public IEnumerable<Orders> GetAllProducts()
		{
			var Orders = dbContext.Orders;
			return Orders;
		}

		public  IEnumerable<Orders> GetAllOrdesById(int userId)
		{
			var Order = (IEnumerable<Orders>)  dbContext.Orders
    .Include(x => x.LocalUser)
    .Where(c => c.LocalUserId == userId)
    .ToListAsync();

			return Order;
		}
	}
}
