namespace EmployeeAdminPortal.Models.Entity
{
    public class Farmer
    {
        public int Id { get; set; }
        public String? name;
        public String? email;
        public String? phoneNumber;
        public String? cropType;   
        public DateOnly registrationDate;  
        public String? bankAccountNumber;
        public String? aadharNumber; 
        public String? panNumber;    
        public Boolean isActive;

        // Foreign key for Address   
        public int AddressId { get; set; }

        public Address Address { get; set; } = null!;

        public ICollection<Crop> Crops { get; set; } = new List<Crop>();

        public ICollection<Cattle> Cattles { get; set; } = new List<Cattle>();




    }
}
