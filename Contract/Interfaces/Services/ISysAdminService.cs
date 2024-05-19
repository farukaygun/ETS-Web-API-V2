namespace Contract.Interfaces.Services;

public interface ISysAdminService
{
    public Task<CreateManagerDto> CreateManagerWithUserManager(CreateManagerDto entity);
    public Task<CreateEmployeeDto> CreateEmployeeWithUserManager(CreateEmployeeDto entity);
}
