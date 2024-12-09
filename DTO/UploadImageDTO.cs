namespace EmployeeAdminPortal.DTO
{
    public class UploadImageDTO
    {
        public string ImageName { get; set; }


        public string EmployeeId { get; set; } = string.Empty;
        public IFormFile file { get; set; }
    }
}
