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
        public bool IsDeleted { get; set; } = false; //by default false

        public int ImageId { get; set; } // Foreign key for the uploaded image
        public UploadImage Image { get; set; } // Navigation property

        public int AddressId { get; set; }
        public Address? Address { get; set; }

        public int CropId { get; set; }
        public Crop? Crop { get; set; }
    }
}
    
    


  
   







