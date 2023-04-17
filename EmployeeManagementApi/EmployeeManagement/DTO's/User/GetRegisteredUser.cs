namespace EmployeeManagement.DTO_s.User
{
    public class GetRegisteredUser
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
