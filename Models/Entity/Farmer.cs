using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeAdminPortal.Models.Entity
{
    public class Farmer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? AadharNumber { get; set; }
        public string? PanNumber { get; set; }

        public int AddressId { get; set; } // FK to Address
        public Address? Address { get; set; } // Navigation Property to Address

        // Navigation Property for related Crops
        public List<Crop> Crops { get; set; } = new List<Crop>();
    }

    
}
