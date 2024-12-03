namespace EmployeeAdminPortal.Models.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string Village { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;


    }
}
