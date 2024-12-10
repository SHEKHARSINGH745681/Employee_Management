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


        //F.K
        public int? ImageId { get; set; }
        public int AddressId { get; set; }
        public int CropId { get; set; }
        public int CattleId { get; set; }

        //Navigation
        public Address? Address { get; set; }
        public UploadImage? UploadImage { get; set; }
        public Crop? Crop { get; set; }
        public Cattle? Cattle { get; set; } 


      
    }

    
}
