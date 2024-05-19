using AutoMapper;
using Contract;
using Contract.Interfaces.Services;
using ETS_Web_API_V2.Validators.SysAdmin;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETS_Web_API_V2.Controllers;

[Authorize(Roles = "SysAdmin")]
[Route("api/v1/[controller]s")]
[ApiController]
public class SysAdminController(IMapper mapper,
	ISysAdminService sysAdminService) : ControllerBase
{
	[HttpPost("manager")]
	public async Task<IActionResult> CreateManager([FromBody] CreateManagerModel model)
	{
		var validator = new CreateManagerValidator();
		await validator.ValidateAndThrowAsync(model);

		var newManagerDto = mapper.Map<CreateManagerDto>(model);
		var response = await sysAdminService.CreateManagerWithUserManager(newManagerDto);

		return CreatedAtAction(nameof(CreateManager), response);
	}

	[HttpPost("employee")]
	public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeModel model)
	{
		var validator = new CreateEmployeeValidator();
		await validator.ValidateAndThrowAsync(model);

		var newEmployeeDto = mapper.Map<CreateEmployeeDto>(model);
		var response = await sysAdminService.CreateEmployeeWithUserManager(newEmployeeDto);

		return CreatedAtAction(nameof(CreateEmployee), response);
	}
}
