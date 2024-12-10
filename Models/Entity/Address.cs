
using System.Text.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models.Entity
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string ?Street { get; set; }
        public string ?City { get; set; }
        public string ?State { get; set; }
        public string ?ZipCode { get; set; }
       
    }
}

