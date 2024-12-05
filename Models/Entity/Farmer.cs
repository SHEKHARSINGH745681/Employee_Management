namespace EmployeeAdminPortal.Models.Entity
{
    public class Farmer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string Description { get; set; } = string.Empty;

        // Foreign key for Address   
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;





    }
}
