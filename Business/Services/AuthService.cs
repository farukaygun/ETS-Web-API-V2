using System.Security.Claims;
using AutoMapper;
using Contract.Base;
using Contract.Dto;
using Contract.Dto.Auth;
using Contract.Enums;
using Contract.Interfaces.Repositories;
using Contract.Interfaces.Services;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Contract.Services;

public class AuthService(IMapper mapper,
		IAuthRepository authRepository,
		UserManager<BaseUser> userManager,
		ITokenService tokenService) : IAuthService
{
	public async Task<ApiResponse<LoginResponseDto>> Login(LoginDto dto)
	{
		var user = await userManager.FindByNameAsync(dto.Email!)
				?? throw new ArgumentException("User not found!");

			var userRoles = await userManager.GetRolesAsync(user);

			var passwordHasher = new PasswordHasher<BaseUser>();
			var passwordVerified = passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, dto.Password!);


			if (passwordVerified != PasswordVerificationResult.Success)
				throw new Exception("Invalid Password!");

			var claims = new List<Claim>
			{
				new(ClaimTypes.Name, user.UserName!),
				new(ClaimTypes.NameIdentifier, user.Id.ToString())
			};

			foreach (var userRole in userRoles)
			{
				claims.Add(new Claim(ClaimTypes.Role, userRole));
			}

			var token = tokenService.CreateAccessToken(claims);

			return new ApiResponse<LoginResponseDto>()
		{
			Success = true,
			Data = new LoginResponseDto()
			{
				Token = token,
				UserName = user.UserName,
				Email = user.Email
			},
			Message = "User logged in successfully!",
			StatusCode = 200
		};
	}

	public async Task<ApiResponse<RegisterDto>> Register(RegisterDto dto)
	{
		var user = await userManager.FindByEmailAsync(dto.Email!);
			if (user is not null) throw new Exception("Email already exists!");

			user = await userManager.FindByNameAsync(dto.UserName!);
			if (user is not null) throw new Exception("Username already exists!");

			var newUser = mapper.Map<SysAdmin>(dto);

			var passwordHasher = new PasswordHasher<IdentityUser>();
			newUser.PasswordHash = passwordHasher.HashPassword(newUser, dto.Password!);

			await authRepository.CreateWithUserManager(newUser, UserRoles.SysAdmin.ToString());

			return new ApiResponse<RegisterDto>()
			{
				Success = true,
				Data = mapper.Map<RegisterDto>(newUser),
				Message = "User created successfully!",
				StatusCode = 201
			};
	}
}