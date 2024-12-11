
using System.Text.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models.Entity
{
    public class UploadImage
    {
        [Key]
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string? Url { get; set; }
        public bool IsDeleted { get; set; } // Add this field
        [NotMapped]
        public IFormFile? File { get; set; } // Not mapped to the database

       
    }






}





