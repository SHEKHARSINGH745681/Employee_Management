using EmployeeAdminPortal.DTO;

namespace EmployeeAdminPortal.IRepo
{
    public interface IAuthRepo
    {
        Task<string> AuthenticateAsync(LoginDTO loginDto);
        Task<string> RegisterAsync(RegisterDTO registerDto);
    }
}
