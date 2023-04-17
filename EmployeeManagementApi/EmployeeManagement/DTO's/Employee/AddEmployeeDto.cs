namespace EmployeeManagement.DTO_s.Employee
{
    public class AddEmployeeDto
    {
       public int UserId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
