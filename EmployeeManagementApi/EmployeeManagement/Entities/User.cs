﻿namespace EmployeeManagement.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }  = string.Empty;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        
        public string Role { get; set; } = string.Empty;
        public List<Employee>? Employees { get; set; }

    }
}
