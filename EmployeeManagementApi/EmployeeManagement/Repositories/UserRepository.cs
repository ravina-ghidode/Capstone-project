using AutoMapper;
using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.DTO_s;
using EmployeeManagement.DTO_s.Employee;

using EmployeeManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserRepository(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public  async Task<ServiceResponse<List<GetAllUsersDto>>> GetAllUsers()
        {
            
            
                var serviceResponse = new ServiceResponse<List<GetAllUsersDto>>();
                var data = await _context.Employees.Select(e => _mapper.Map<GetAllUsersDto>(e)).ToListAsync();
                serviceResponse.Data = data;
                return serviceResponse;
            

        }

        public  async  Task<ServiceResponse<GetAllUsersDto>> GetUserById(int employeeId)
        {
            var serviceResponse = new ServiceResponse<GetAllUsersDto>();
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            serviceResponse.Data = _mapper.Map<GetAllUsersDto>(employee);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAllUsersDto>> UpdateUser(UpdateEmployeeDto updateEmployeeDto)
        {
            var serviceResponse = new ServiceResponse<GetAllUsersDto>();
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == updateEmployeeDto.Id);

                if (employee == null)
                {
                    throw new Exception($"employee with id '{updateEmployeeDto.Id}' is not found");
                }

                employee.EmployeeName = updateEmployeeDto.EmployeeName;
                employee.Email = updateEmployeeDto.Email;
                employee.ContactNo = updateEmployeeDto.ContactNo;
                employee.Department = updateEmployeeDto.Department;


                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetAllUsersDto>(employee);

            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;

            }

            return serviceResponse;
        }

      }
}
