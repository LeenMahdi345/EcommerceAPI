using AutoMapper;
using Ecommerce.Core.Entites.DTO;
using Ecommerce.Core.Entites;

namespace Ecommerce.API.MappingProfile
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Products, ProductDTO>()
				.ForMember(To => To.Category_Id, from => from.MapFrom(x => x.category!= null? x.category.Id : 0));
		}

	}

}
