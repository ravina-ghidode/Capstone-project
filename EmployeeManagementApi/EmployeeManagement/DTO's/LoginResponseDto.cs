namespace EmployeeManagement.DTO_s
{
    public class LoginResponseDto
    {
        public string UserName { get; set; } = string.Empty;
        public string? Token { get; set; } = string.Empty;
        public string  Role { get; set; } = string.Empty ;
    }
}
