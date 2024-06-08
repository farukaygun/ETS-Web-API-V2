using Contract.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETS_Web_API_V2.Controllers;

[Authorize(Roles = "Employee")]
[Route("api/v1/[controller]s")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
	[HttpGet("expenses/{employeeId}")]
	public async Task<IActionResult> GetAllById(string employeeId)
	{
		var result = await employeeService.GetExpensesById(employeeId);
		return Ok(result);
	}
}
