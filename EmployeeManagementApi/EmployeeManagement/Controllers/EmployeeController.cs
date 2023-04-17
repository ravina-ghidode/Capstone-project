using EmployeeManagement.Contracts;
using EmployeeManagement.DTO_s;
using EmployeeManagement.DTO_s.Employee;
using EmployeeManagement.DTO_s.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
       /* [HttpGet]
        public async Task<ActionResult<List<GetAllUsersDto>>> GetAllData()
        {
            var response = await _employeeRepository.GetAllData();  
            return Ok(response);
        }*/
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<GetEmployeeDto>>> GetUsers(int userId)
        {
            return Ok(await _employeeRepository.GetEmployeeForUser(userId));
        }
        [HttpGet("/emp/{empId}")]
        public async Task<ActionResult<List<GetEmployeeDto>>> GetUserById(int employeeId)
        {
            return Ok(await _employeeRepository.GetEmployeesByEmployeeId(employeeId));
        }
         [HttpPost]
         public async Task<ActionResult<List<GetEmployeeDto>>> AddEmployees(AddEmployeeDto newEmployee)
         {
             return Ok(await _employeeRepository.AddEmployeeForUser(newEmployee));
         }
       /* [HttpPost]
        public async Task<ActionResult<List<GetAllUsersDto>>> AddEmployee(AddUserDto addUserDto)
        {
            return Ok(await _employeeRepository.AddUser(addUserDto));
        }*/

       /* [HttpPut]
        public async Task<ActionResult<GetEmployeeDto>> UpdateEmployee(UpdateEmployeeDto updatedEmployee)
        {
            var response = await _employeeRepository.UpdateEmployeeByUser(updatedEmployee);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }*/

        [HttpDelete]
        public async Task<ActionResult<List<GetEmployeeDto>>> DeleteEmployee(int employeeId)
        {
            var response = await _employeeRepository.DeleteEmployeeForUser(employeeId);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
