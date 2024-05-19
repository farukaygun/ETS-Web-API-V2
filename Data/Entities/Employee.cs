using Contract.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
	public class Employee : BaseUser
	{
		public string? ManagerId { get; set; }

		[ForeignKey("ManagerId")]
		public Manager? Manager { get; set; }
		public ICollection<Expense>? Expenses { get; set; }
	}
}
