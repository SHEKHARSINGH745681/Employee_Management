using EmployeeAdminPortal.DTO;

namespace EmployeeAdminPortal.IRepo
{
    public interface IAuthRepo
    {
        Task<AuthResponseDTO> AuthenticateAsync(LoginDTO loginDto);
        Task<string> RegisterAsync(RegisterDTO registerDto);
    }
}
