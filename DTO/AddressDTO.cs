using EmployeeAdminPortal.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeAdminPortal.DTO
{
    public class AddressDTO
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
