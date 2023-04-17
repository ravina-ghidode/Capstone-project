using EmployeeManagement.DTO_s;
using EmployeeManagement.DTO_s.Employee;
using EmployeeManagement.Entities;
using EmployeeManagement.DTO_s.User;

namespace EmployeeManagement.Contracts
{
    public interface IEmployeeRepository
    {
        Task<ServiceResponse<List<GetEmployeeDto>>> GetEmployeeForUser(int userId);
        Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployeeForUser(AddEmployeeDto newEmployee);
        Task<ServiceResponse<List<GetEmployeeDto>>> DeleteEmployeeForUser(int employeeId);
        Task<ServiceResponse<GetEmployeeDto>> GetEmployeesByEmployeeId(int employeeId);
      
        
    }
}
