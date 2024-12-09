using System;
using System.ComponentModel.DataAnnotations;
namespace EmployeeAdminPortal.Models
{
	public class UploadImage
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageName { get; set; }
       public string EmployeeId { get; set; } = string.Empty;
        [Required]
        public string Url { get; set; }
    }

}

	


