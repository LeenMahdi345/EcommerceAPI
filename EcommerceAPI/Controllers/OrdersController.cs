using AutoMapper;
using Ecommerce.Core.Entites.DTO;
using Ecommerce.Core.Entites;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Core.IReositories;

namespace Ecommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
	
	
			private readonly IMapper mapper;
			private readonly IUnitOfWork<Orders> unitOfWork;

			public OrdersController(IMapper mapper, IUnitOfWork<Orders> unitOfWork)
			{
				this.mapper = mapper;
				this.unitOfWork = unitOfWork;
			}
		[HttpGet("Order/{userId}")]
		public ActionResult<ApiResponse> GetOrders(int userId)
		{

			var order = unitOfWork.OrdersRepository.GetAllOrdesById(userId);
			
			return Ok(order);
		}

	}
}
