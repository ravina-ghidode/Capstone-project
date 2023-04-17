namespace EmployeeManagement.DTO_s.Employee
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? EmployeeName { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        
    }
}
