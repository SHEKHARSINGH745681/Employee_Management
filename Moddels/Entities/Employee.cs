using EmployeeAdminPortal.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Moddels.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public decimal Salary { get; set; }

        // Correct ForeignKey attribute
        [ForeignKey(nameof(Department))]
        public int Dep_Id { get; set; }

        public Department? Department { get; set; } // Navigation property


    }
}
