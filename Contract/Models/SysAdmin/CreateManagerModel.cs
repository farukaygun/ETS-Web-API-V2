namespace Contract.Models.SysAdmin;

public record CreateManagerModel
{
	public required string UserName { get; init; }
	public required string Email { get; init; }
	public required string Password { get; init; }
}
