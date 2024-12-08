using System;
namespace EmployeeAdminPortal.Models
{
	public class UploadImage
	{
		public required string ImageName { get; set; }

		public IFormFile? file { get; set; }

	}
}
	


