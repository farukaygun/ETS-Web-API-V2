using AutoMapper;
using Contract.Base;
using Contract.Dto.Manager;
using Contract.Interfaces.Services;
using Contract.Models.Manager;
using ETS_Web_API_V2.Validators.Manager;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace ETS_Web_API_V2.Controllers;

[Authorize(Roles = "Manager")]
[Route("api/v1/[controller]s")]
[ApiController]
public class ManagerController(IMapper mapper,
	UserManager<BaseUser> userManager,
	IManagerService managerService) : ControllerBase
{
	[HttpGet("expenses")]
	public async Task<IActionResult> GetExpenses()
	{
		var id = userManager.GetUserId(User)
			?? throw new AuthenticationException("User not logged in!");

		var response = await managerService.GetExpenses(id);

		return Ok(response);
	}

	[HttpPatch("expense")]
	public async Task<IActionResult> PatchExpense([FromBody] PatchExpenseModel model)
	{
		var validator = new PatchExpenseValidator();
		await validator.ValidateAndThrowAsync(model);

		var id = userManager.GetUserId(User)
			?? throw new AuthenticationException("User not logged in!");
		var patchExpenseDto = mapper.Map<PatchExpenseDto>(model);

		await managerService.PatchExpense(id, patchExpenseDto);
		return Ok();
	}
}
