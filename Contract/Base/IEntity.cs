namespace Contract.Base
{
	public interface IEntity
	{
		public Guid Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
