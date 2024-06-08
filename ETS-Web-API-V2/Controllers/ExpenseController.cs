using AutoMapper;
using Contract.Base;
using Contract.Dto.Expense;
using Contract.Interfaces.Services;
using Contract.Models.Expense;
using ETS_Web_API_V2.Validators.Expense;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETS_Web_API_V2.Controllers;

[Authorize(Roles = "Employee")]
[Route("api/v1/[controller]s")]
[ApiController]
public class ExpenseController(IMapper mapper,
	UserManager<BaseUser> userManager,
	IExpenseService expenseService) : ControllerBase
{
	[HttpPost]
	public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseModel model)
	{
		var id = userManager.GetUserId(User) ?? "0";
		model.EmployeeId = id;

		var validator = new CreateExpenseValidator();
		await validator.ValidateAndThrowAsync(model);

		var createExpenseDto = mapper.Map<CreateExpenseDto>(model);

		var result = await expenseService.Create(createExpenseDto);
		return Ok(result);
	}
}
