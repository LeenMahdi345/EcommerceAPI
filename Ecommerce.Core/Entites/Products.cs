using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entites
{
	public class Products
	{

		public int Id { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public string? Image { get; set; }
		[ForeignKey(nameof(Category_Id))]
		public int Category_Id { get; set; }
		public  Categories? category { get; set; }
		public ICollection<OrderDetails>? OrderDetails { get; set; } = new HashSet<OrderDetails>();

	}
}
