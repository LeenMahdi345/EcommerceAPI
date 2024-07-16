using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entites
{
	public class LocalUser
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Username { get; set; }
		public string Password { get; set; }
		public string? Phone { get; set; }
		public string Role { get; set; }
		public ICollection<Orders> OrderDetails { get; set; } = new HashSet<Orders>();

	}
}
