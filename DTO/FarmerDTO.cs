
using EmployeeAdminPortal.Models.Entity;
using System;

namespace EmployeeAdminPortal.DTO
{
    public class FarmerDTO
    {
            public string? Name { get; set; }
            public string? PhoneNumber { get; set; }
            public string? PanNumber { get; set; }
            public DateTime RegistrationDate { get; set; }
            public string? Email { get; set; }
            public string? BankAccountNumber { get; set; }
            public string? AadharNumber { get; set; }
            public string? CropName { get; set; }
            public string? Season { get; set; }
            public int Quantity { get; set; }
            public string? HarvestDate { get; set; }
            public string? Street { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? ZipCode { get; set; }
           
            public IFormFile file { get; set; } 
        }

    }





