using System;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Echo;
using EmployeeAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost("UploadImage")]
        public async Task<ActionResult<Echos>> UploadImage([FromForm] UploadImage uploadImage)
        {
            //if (model.file == null || model.file.Length == 0)
            //    return Echos.Error("No file provided or the file is empty.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
            Directory.CreateDirectory(uploadsFolder); // Ensure the folder exists

            var filePath = Path.Combine(uploadsFolder, uploadImage.FileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            /await uploadImage.file.CopyToAsync(stream);

            return Echos.Ok("Image uploaded successfully.");
        }
    }
}
