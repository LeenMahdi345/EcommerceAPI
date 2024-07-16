using Ecommerce.Core.Entites;
using Ecommerce.Core.Entites.DTO;
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
	public class ProductRepository : GenericRepository<Products>,IProductRepositories
	{
		private readonly AppDbContext dbContext;
		private IEnumerable<Products> model;

		public ProductRepository(AppDbContext dbContext) : base(dbContext)
		{
			this.dbContext = dbContext;

		}

		public void Create(IEnumerable<Products> mappedProducts)
		{
			dbContext.Products.Add((Products)model);
		}

		public void CreateProduct(Products model)
		{
			dbContext.Products.Add(model);
		}

		public void DeleteProduct(int id)
		{
			var model = dbContext.Products.Find(id);
			dbContext.Products.Remove(model);

		}

		public IEnumerable<Products> GetAllProducts()
		{
		var products = dbContext.Products;
			return products;
		}

		public Products GetById(int id)
		{
			return dbContext.Products.Find(id);
		}

		public void UpdateProduct(Products model)
		{
			dbContext.Products.Update(model);
		}
	}
}
