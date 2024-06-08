using AutoMapper;
using Contract.Dto.Auth;
using Contract.Dto.Common;
using Contract.Dto.Expense;
using Contract.Dto.Manager;
using Contract.Dto.SysAdmin;
using Contract.Models.Auth;
using Contract.Models.Expense;
using Contract.Models.Manager;
using Contract.Models.SysAdmin;
using Data.Entities;

namespace Business
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			ModelToDto();
			DtoToEntity();
		}

		public void ModelToDto()
		{
			CreateMap<LoginModel, LoginDto>().ReverseMap();
			CreateMap<RegisterModel, RegisterDto>().ReverseMap();
			CreateMap<CreateManagerModel, CreateManagerDto>().ReverseMap();
			CreateMap<CreateEmployeeModel, CreateEmployeeDto>().ReverseMap();
			CreateMap<CreateExpenseModel, CreateExpenseDto>().ReverseMap();
			CreateMap<PatchExpenseModel, PatchExpenseDto>().ReverseMap();
		}

		public void DtoToEntity()
		{
			CreateMap<LoginDto, SysAdmin>().ReverseMap();
			CreateMap<RegisterDto, SysAdmin>().ReverseMap();
			CreateMap<GetExpenseDto, Expense>().ReverseMap();
			CreateMap<CreateManagerDto, Manager>().ReverseMap();
			CreateMap<CreateEmployeeDto, Employee>().ReverseMap();
			CreateMap<CreateExpenseDto, Expense>().ReverseMap();
		}
	}
}