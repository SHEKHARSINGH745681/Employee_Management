using EmployeeAdminPortal.Models.Entity;

namespace EmployeeAdminPortal.DTO
{
    public class FarmerDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public AddressDTO Address { get; set; } = new AddressDTO();

    }
}
