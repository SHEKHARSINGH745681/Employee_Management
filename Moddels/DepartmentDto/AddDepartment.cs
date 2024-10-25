using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Moddels.DepartmentDto
{
    public class AddDepartment
    {

        public required int Id { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public required string Address { get; set; }
        public required string BloodGroup { get; set; }
        public required string Position { get; set; }
        public required string Experience { get; set; }


    }
}
