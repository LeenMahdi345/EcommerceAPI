using Ecommerce.Core.Entites;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IReositories
{
	public interface IProductRepositories:IGenericRepository<Products>
	{
		IEnumerable<Products> GetAllProducts();
		Products GetById(int id);
		void CreateProduct(Products model);
		void UpdateProduct(Products model);
		void DeleteProduct(int id);
		void Create(IEnumerable<Products> mappedProducts);
	}

}
