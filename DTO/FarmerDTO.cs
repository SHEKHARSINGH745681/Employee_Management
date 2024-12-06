
using EmployeeAdminPortal.Models.Entity;

namespace EmployeeAdminPortal.DTO
{
    public class FarmerDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? AadharNumber { get; set; }
        public string? PanNumber { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public AddressDTO? Address { get; set; } 

        public CropDTO? Crop { get; set; }
       

    }


}


