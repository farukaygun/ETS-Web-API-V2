using Microsoft.AspNetCore.Identity;

namespace Contract.Base
{
	public class BaseUser : IdentityUser, IEntity
	{
		public new Guid Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
