﻿using Ecommerce.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.IReositories
{
	public interface IGenericRepository <T> where T : class
	{
		public Task < IEnumerable<T>> GetAll();
		 public Task <T> GetById(int id);
		public Task Create(T model);
		public void Update(T model);
		public void Delete(int id);
	}
}
