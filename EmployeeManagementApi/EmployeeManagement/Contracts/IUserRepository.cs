using EmployeeManagement.DTO_s;
using EmployeeManagement.DTO_s.Employee;
using EmployeeManagement.DTO_s.User;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Contracts
{
    public interface IUserRepository
    {
       
        Task<ServiceResponse<List<GetAllUsersDto>>> GetAllUsers();
        Task<ServiceResponse<GetAllUsersDto>> GetUserById(int employeeId);
        Task<ServiceResponse<GetAllUsersDto>> UpdateUser(UpdateEmployeeDto updateEmployeeDto);
       
    }
}
