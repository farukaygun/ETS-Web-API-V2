using Contract.Base;
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Db_Context
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<BaseUser>(options)
	{
		public DbSet<SysAdmin> SysAdmins { get; set; }
		public DbSet<Manager> Managers { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Expense> Expenses { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Employee>()
				.HasOne(e => e.Manager)
				.WithMany(m => m.Employees)
				.HasForeignKey(e => e.ManagerId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Manager>()
				.HasMany(m => m.Employees)
				.WithOne(e => e.Manager)
				.HasForeignKey(e => e.ManagerId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Expense>()
				.HasOne(e => e.Employee)
				.WithMany(emp => emp.Expenses)
				.HasForeignKey(e => e.EmployeeId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
