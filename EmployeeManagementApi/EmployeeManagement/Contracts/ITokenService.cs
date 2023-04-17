using EmployeeManagement.Entities;

namespace EmployeeManagement.Contracts
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
