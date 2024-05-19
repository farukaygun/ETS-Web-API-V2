using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contract.Base;
using Contract.Interfaces.Repositories;
using Data.Db_Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
	public class AuthRepository(AppDbContext context,
		UserManager<BaseUser> userManager,
		RoleManager<IdentityRole> roleManager) : GenericRepository<BaseEntity>(context), IAuthRepository
	{
		private readonly AppDbContext _context = context;

		public async Task CreateWithUserManager(BaseUser entity, string role)
		{
			entity.CreatedAt = DateTime.Now;
			var result = await userManager.CreateAsync(entity);

			var roleName = role.ToString();
			if (result.Succeeded)
			{
				if (!roleManager.RoleExistsAsync(roleName).Result)
					await roleManager.CreateAsync(new IdentityRole(roleName));

				await userManager.AddToRoleAsync(entity, roleName);
				await _context.SaveChangesAsync();
			}
			else throw new Exception($"Failed to create {roleName}!");
		}
	}
}