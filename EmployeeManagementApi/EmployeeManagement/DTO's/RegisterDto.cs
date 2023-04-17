﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.DTO_s
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }= string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; }   = string.Empty ;
    }
}
