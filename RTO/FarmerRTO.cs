
namespace EmployeeAdminPortal.RTO
{
    public class FarmerRTO
    { 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public AddressRTO Address { get; set; } = new AddressRTO();

    }
}
