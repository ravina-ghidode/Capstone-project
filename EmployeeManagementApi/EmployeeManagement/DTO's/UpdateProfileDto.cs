﻿namespace EmployeeManagement.DTO_s
{
    public class UpdateProfileDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
