
namespace EmployeeAdminPortal.DTO
{
    public class FarmerDTO
    {
        public String? name { get; set; }

        public String? email { get; set; }

        public String? phoneNumber { get; set; }

        public String? bankAccountNumber { get; set; }

        public String? aadharNumber { get; set; }

        public String? panNumber { get; set; }

        public Boolean isActive;

        public AddressDTO Address { get; set; } = new AddressDTO();

        public CattleDTO Cattle { get; set; } = new CattleDTO();

        public CropDTO Crop { get; set; } = new CropDTO();
        
    }


}


