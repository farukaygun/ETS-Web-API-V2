using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Models
{
	public record LoginModel
	{
		public required string UserName { get; init; }
		public required string Email { get; init; }
		public required string Password { get; init; }
	}
}
