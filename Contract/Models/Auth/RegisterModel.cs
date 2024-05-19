namespace Contract.Models
{
	public record RegisterModel
	{
		public required string UserName { get; init; }
		public required string Email { get; init; }
		public required string Password { get; init; }
		// public required string Role { get; init; }
	}
}
