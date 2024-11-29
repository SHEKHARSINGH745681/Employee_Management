using EmployeeAdminPortal.Models;
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
        public string? Lastname { get; set; }
        public int DepartmentId { get; set; }







        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; } 

    }
}
