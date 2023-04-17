using AutoMapper;
using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.DTO_s;
using EmployeeManagement.DTO_s.Employee;
using EmployeeManagement.DTO_s.User;
using EmployeeManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeRepository(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<List<GetEmployeeDto>>> AddEmployeeForUser(AddEmployeeDto newEmployee)
         {
             var serviceResponse = new ServiceResponse<List<GetEmployeeDto>>();

             var employee = _mapper.Map<Employee>(newEmployee);
             _context.Employees.Add(employee);
             await _context.SaveChangesAsync();
             serviceResponse.Data = await _context.Employees.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToListAsync();
             return serviceResponse;
         }

        public async  Task<ServiceResponse<List<GetEmployeeDto>>> DeleteEmployeeForUser(int employeeId)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeDto>>();
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId );
                if (employee == null)
                {
                    throw new Exception($"character with id '{employeeId}' is not found");
                }
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                serviceResponse.Data =   await _context.Employees.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToListAsync();


            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetEmployeeForUser(int userId)
        {
            var serviceResponse = new ServiceResponse<List<GetEmployeeDto>>();
            serviceResponse.Data = await _context.Employees.Where(e => e.UserId == userId).Select(e => _mapper.Map<GetEmployeeDto>(e)).ToListAsync();
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetEmployeeDto>> GetEmployeesByEmployeeId(int employeeId)
        {
            var serviceResponse = new ServiceResponse<GetEmployeeDto>();
           var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            serviceResponse.Data = _mapper.Map<GetEmployeeDto>(employee);
            return serviceResponse;


        }

     
    }
}
