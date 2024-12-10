using System;
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Echo;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers.Image
{

    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private string FormatFileSize(long sizeInBytes)
        {
            if (sizeInBytes >= 1024 * 1024)
                return $"{sizeInBytes / (1024 * 1024):0.##} MB";
            if (sizeInBytes >= 1024)
                return $"{sizeInBytes / 1024:0.##} KB";
            return $"{sizeInBytes} bytes";
        }
        public UploadController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("UploadImage")]
        public async Task<ActionResult<Echos>> UploadImage([FromForm] UploadImage uploadImage)
        {
            if (uploadImage.File?.Length <= 0)
                return Echos.BadRequest("No file provided or the file is empty.");

            const long maxFileSize = 10 * 1024 * 1024; // 10 MB in bytes

            if (uploadImage.File.Length > maxFileSize)
                return Echos.BadRequest("File size greater than 10 MB limit.");

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(uploadImage.File.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
                return Echos.BadRequest("Invalid file type. Only JPG, PNG, and GIF are allowed.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileNameWithoutExtension(uploadImage.ImageName)}{fileExtension}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await uploadImage.File.CopyToAsync(stream);

            byte[] imageData = null;
            if (uploadImage.File.Length > 0)
            {
                await using (var ms = new MemoryStream())
                {
                    await uploadImage.File.CopyToAsync(ms);
                    imageData = ms.ToArray();
                }
            }

            var uploadImageEntity = new UploadImage
            {
                ImageName = uploadImage.ImageName,
                ImageData = imageData,
                Url = filePath
            };

            _dbContext.UploadImages.Add(uploadImageEntity);
            await _dbContext.SaveChangesAsync();

            var fileSizeInBytes = imageData.Length;

            return Echos.Ok(new
            {
                Message = "Image uploaded successfully.",
                FilePath = filePath,
                FileSizeInBytes = imageData
            });
        }


        [HttpGet("GetImage/{id}")]
        public async Task<ActionResult> GetImage(int id)
        {
            var Image = await _dbContext.UploadImages.FindAsync(id);

            if (Image == null)
            {
                return Echos.NotFound("Image not found.");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages", Path.GetFileName(Image.Url));

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            var fileExtension = Path.GetExtension(filePath).ToLowerInvariant();

            return File(fileBytes, "application/octet-stream", $"{Image.ImageName}{fileExtension}");
        }
    }
}






