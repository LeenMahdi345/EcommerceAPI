using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IReositories
{
	public interface IUnitOfWork <T> where T : class
	{
		public IProductRepositories productRepository { get; set; }
		public IOrdersRepositories OrdersRepository { get; set; }
		public int Save();
	}
}
