using AutoMapper;
using Contract.Base;
using Contract.Dto.SysAdmin;
using Contract.Enums;
using Contract.Interfaces.Services;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

public class SysAdminService(IMapper mapper,
		UserManager<BaseUser> userManager,
		IUnitOfWork unitOfWork) : ISysAdminService
{
	public async Task<CreateEmployeeDto> CreateEmployeeWithUserManager(CreateEmployeeDto dto)
	{
		var user = await userManager.FindByEmailAsync(dto.Email);
		if (user is not null) throw new Exception("Email already exists");

		user = await userManager.FindByNameAsync(dto.UserName);
		if (user is not null) throw new Exception("Username already exists");

		var newEmployee = mapper.Map<Data.Entities.Employee>(dto);

		var passwordHasher = new PasswordHasher<IdentityUser>();
		newEmployee.PasswordHash = passwordHasher.HashPassword(newEmployee, dto.Password);

		await unitOfWork.SysAdmins.CreateWithUserManager(newEmployee, UserRoles.Employee.ToString());
		unitOfWork.Commit();

		return mapper.Map<CreateEmployeeDto>(newEmployee);
	}

	public async Task<CreateManagerDto> CreateManagerWithUserManager(CreateManagerDto dto)
	{
		var user = await userManager.FindByEmailAsync(dto.Email);
		if (user is not null) throw new Exception("Email already exists");

		user = await userManager.FindByNameAsync(dto.UserName);
		if (user is not null) throw new Exception("Username already exists");

		var newManager = mapper.Map<Data.Entities.Manager>(dto);

		var passwordHasher = new PasswordHasher<IdentityUser>();
		newManager.PasswordHash = passwordHasher.HashPassword(newManager, dto.Password);

		await unitOfWork.SysAdmins.CreateWithUserManager(newManager, UserRoles.Manager.ToString());
		unitOfWork.Commit();

		return mapper.Map<CreateManagerDto>(newManager);
	}
}
