using AutoMapper;
using Contract.Dto.Auth;
using Contract.Dto.Employee;
using Contract.Models;
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
        }

        public void DtoToEntity()
        {
            CreateMap<LoginDto, SysAdmin>().ReverseMap();
            CreateMap<RegisterDto, SysAdmin>().ReverseMap();
            CreateMap<GetExpenseDto, Expense>().ReverseMap();
        }
    }
}