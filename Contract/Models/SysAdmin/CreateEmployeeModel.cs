﻿namespace Contract.Models.SysAdmin;

public record CreateEmployeeModel
{
	public required string UserName { get; init; }
	public required string Email { get; init; }
	public required string Password { get; init; }
	public required Guid ManagerId { get; init; }
}
