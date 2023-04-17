using AutoMapper;
using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.DTO_s;
using EmployeeManagement.DTO_s.User;
using EmployeeManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(DataContext context, ITokenService tokenService, IMapper mapper)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        [HttpPost("register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDTO)
        {
            if (await UserExists(registerDTO.UserName!))
            {
                return BadRequest("Username is taken");
            }
            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = registerDTO?.UserName?.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO?.Password!)),
                PasswordSalt = hmac.Key,
                Role = registerDTO.Role

            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var result = new UserDto
            {

                UserName = user.UserName,
                Role = user.Role,
                Token = _tokenService.CreateToken(user),
            };
            return result;

        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDTO.UserName);
            if (user == null)
                return Unauthorized("Invalid UserName");


            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return Unauthorized("Invalid Password");
            }
            var result = new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                Role = user.Role,
                Id = user.Id
            };
            return result;



        }
        [HttpPut("{userId}")]
        public async Task<ActionResult<GetProfileDto>> UpdateProfile(UpdateProfileDto updateProfileDto,int userId)
        {
            
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null)
                {
                    throw new Exception($"user with id '{userId}' is not found");
                }
                user.UserName = updateProfileDto.UserName;
                user.Role = updateProfileDto.Role;
               
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<GetProfileDto>(user);
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<GetRegisteredUser>> GetUserByUserId(int userId)
        {
            var employee = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return _mapper.Map<GetRegisteredUser>(employee);
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName!.ToLower() == username.ToLower());
        }
    }
}
