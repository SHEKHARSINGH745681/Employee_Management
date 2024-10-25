using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Moddels
{
        public class AddEmployeeDto
        {
            [Required(ErrorMessage = "Name is required.")]
            public required string Name { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email format.")]
            public required string Email { get; set; }

            [Required(ErrorMessage = "Phone is required.")]
            [Phone(ErrorMessage = "Invalid phone number format.")]
            public required string Phone { get; set; }

            public decimal Salary { get; set; }

        public int Dep_Id { get; set; }



    }
    }

