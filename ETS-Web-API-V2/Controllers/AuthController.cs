using AutoMapper;
using Contract.Dto.Auth;
using Contract.Interfaces.Services;
using Contract.Models.Auth;
using ETS_Web_API_V2.Validators.Auth;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ETS_Web_API_V2.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class AuthController(IMapper mapper,
		IAuthService authService) : ControllerBase
	{
		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginModel model)
		{
			var validator = new LoginValidator();
			await validator.ValidateAndThrowAsync(model);

			var loginDto = mapper.Map<LoginDto>(model);
			var response = await authService.Login(loginDto);

			return Ok(response);
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			var validator = new RegisterValidator();
			await validator.ValidateAndThrowAsync(model);

			var registerDto = mapper.Map<RegisterDto>(model);
			var response = await authService.Register(registerDto);

			return CreatedAtAction(nameof(Register), response);
		}
	}
}
