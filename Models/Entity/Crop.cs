using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeAdminPortal.Models.Entity
{
    public class Crop
    {
        [Key]
        public int Id { get; set; }
        public string CropName { get; set; } = null!;
        public string? Season { get; set; }
        public double Quantity { get; set; }
        public string? HarvestDate { get; set; }
        public bool IsDeleted { get; set; } // Add this field



    }
}

