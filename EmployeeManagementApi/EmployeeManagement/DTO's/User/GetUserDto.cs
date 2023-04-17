namespace EmployeeManagement.DTO_s.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
    }
}
