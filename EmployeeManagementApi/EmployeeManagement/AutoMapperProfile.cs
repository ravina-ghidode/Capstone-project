using AutoMapper;
using EmployeeManagement.DTO_s;
using EmployeeManagement.DTO_s.Employee;
using EmployeeManagement.DTO_s.User;
using EmployeeManagement.Entities;

namespace EmployeeManagement
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<Employee, GetEmployeeDto>().ReverseMap();
            CreateMap<AddEmployeeDto, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();
            CreateMap<GetAllUsersDto, Employee>().ReverseMap();
            CreateMap<GetProfileDto, User>().ReverseMap();
            CreateMap<GetRegisteredUser, User>().ReverseMap();
        }
        
    }
}
