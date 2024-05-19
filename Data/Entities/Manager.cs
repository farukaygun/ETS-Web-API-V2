using Contract.Base;

namespace Data.Entities
{
	public class Manager : BaseUser
	{
		public ICollection<Employee>? Employees { get; set; }
	}
}
