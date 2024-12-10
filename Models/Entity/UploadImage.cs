using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace EmployeeAdminPortal.Models.Entity
{
    public class UploadImage
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        [Required]
        public byte[] ImageData { get; set; }
        public string Url { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }





    }
}




