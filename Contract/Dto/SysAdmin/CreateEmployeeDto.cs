namespace Contract;

public record CreateEmployeeDto
{
	public required string UserName { get; set; }
	public required string Email { get; set; }
	public required string Password { get; set; }
	public required Guid ManagerId { get; set; }
}
