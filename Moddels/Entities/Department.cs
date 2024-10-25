using System.ComponentModel.DataAnnotations;
using EmployeeAdminPortal.Moddels.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Models.Entities {
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public required string Address { get; set; }
        public string? BloodGroup { get; set; }
        public string? Position { get; set; }
        public string? Experience { get; set; }

        //public ICollection<Employee> Employees { get; set; } // Navigation property
    }


}

