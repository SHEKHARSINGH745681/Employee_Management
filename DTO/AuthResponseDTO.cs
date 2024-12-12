namespace EmployeeAdminPortal.DTO
{
    public class AuthResponseDTO
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public object UserRole { get; set; }
        public string Token { get; set; }
    }
}