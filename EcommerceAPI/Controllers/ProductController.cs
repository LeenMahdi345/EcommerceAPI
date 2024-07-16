
using AutoMapper;
using Ecommerce.Core.Entites;
using Ecommerce.Core.Entites.DTO;
using Ecommerce.Core.IReositories;
using Ecommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IUnitOfWork<Products> unitOfWork;

		public ProductController(IMapper mapper , IUnitOfWork <Products> unitOfWork)
		{
			this.mapper = mapper;
			this.unitOfWork = unitOfWork;
		}
		[HttpGet]
		public async Task<ActionResult<ApiResponse>> GetAll()
		{
			var model = await unitOfWork.productRepository.GetAll();
			var check = model.Any();

			var response = new ApiResponse();

			if (check)
			{
				response.StatusCode = System.Net.HttpStatusCode.OK;
				response.IsSuccess = check;
				var mappedProducts = mapper.Map<IEnumerable<Products>, IEnumerable<ProductDTO>>(model);
				response.Result = mappedProducts;
				return response;

			}
			else
			{
				response.ErrorMessages = "no products found";
				response.StatusCode = System.Net.HttpStatusCode.OK;
				response.IsSuccess = false;
				return response;
			}
		}


		[HttpGet("{id}")]
		public  async  Task<ActionResult> GetById(int id)
		{
			//var model = dbContext.Products.Find(id);
			var model = unitOfWork.productRepository.GetById(id);
			//var model = genericRepository.GetById(id);

			return Ok(model);
		}
		[HttpPost]

		public async Task<ActionResult<ApiResponse>> CreateProduct(ProductDTO model)
		{
			// productRepository.CreateProduct(model);
			// genericRepository.Create(model);
			
		

			var mappedProducts = mapper.Map<IEnumerable<ProductDTO>, IEnumerable<Products>>((IEnumerable<ProductDTO>)model);
			unitOfWork.productRepository.Create(mappedProducts);

			unitOfWork.Save();
			return Ok();
		}
	
		[HttpPut]
		public async Task <ActionResult<ApiResponse>> UpdateProduct(Products model)
		{
			unitOfWork.productRepository.Update(model);
			//genericRepository.Update(model);
			unitOfWork.Save();
			return Ok(model);
		}

		[HttpDelete]
		public ActionResult DeleteProduct(int id)
		{
			//productRepository.DeleteProduct(id);
			unitOfWork.productRepository.Delete(id);
			unitOfWork.Save();
			return Ok();
		}


	}
}
