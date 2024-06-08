namespace Contract.Base
{
	public interface IEntity
	{
		public string? Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
