using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.DTO_s;
using EmployeeManagement.DTO_s.Employee;
using EmployeeManagement.DTO_s.User;
using EmployeeManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllUsersDto>>> GetAllData()
        {
            var response = await _userRepository.GetAllUsers();
            return Ok(response);
        }
        [HttpGet("{empId}")]
        public async Task<ActionResult<List<GetAllUsersDto>>> GetEmployeeById(int empId)
        {
            var response = await _userRepository.GetUserById(empId);
            return Ok(response);
        }
        [HttpPut]
        public async  Task<ActionResult<GetAllUsersDto>> UpdateUser(UpdateEmployeeDto updateEmployeeDto)
        {
            var response = await _userRepository.UpdateUser(updateEmployeeDto);
            if (response is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
      


    }
}
