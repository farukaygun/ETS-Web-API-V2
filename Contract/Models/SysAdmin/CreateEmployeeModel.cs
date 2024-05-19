namespace Contract;

public class CreateEmployeeModel
{
	public required string UserName { get; set; }
	public required string Email { get; set; }
	public required string Password { get; set; }
	public required Guid ManagerId { get; set; }
}
