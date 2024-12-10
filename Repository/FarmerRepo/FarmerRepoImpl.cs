
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Echo;
using EmployeeAdminPortal.Models.Entity;
using EmployeeAdminPortal.RTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection.Emit;

namespace EmployeeAdminPortal.Repository.CrudRepo
{
    public class FarmerRepoImpl : IFarmer
    {
        private readonly ApplicationDbContext _dbContext;

        public FarmerRepoImpl(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FarmerRTO>> GetFarmerAsync()
        {
            var farmers = await _dbContext.Farmers
                .Include(f => f.Address)
            
                .Select(f => new FarmerRTO
                {
                    name = f.Name,
                    email = f.Email,
                    phoneNumber = f.PhoneNumber,
                    Street = f.Address.Street,
                    City = f.Address.City,
                    State = f.Address.State,
                    ZipCode = f.Address.ZipCode,
                    //CropName = f.Crops.FirstOrDefault().CropName,
                    //Season = f.Crops.FirstOrDefault().Season,
                    //HarvestDate = f.Crops.FirstOrDefault().HarvestDate,
                    //ImageName = f.UploadImage.ImageName
                })
                .ToListAsync();
            return farmers;
        }

        public async Task<ActionResult<Echos>> AddFarmer(FarmerDTO farmerDto)
        {
            // Check if farmer already exists using LINQ query
            var existingFarmer = await (from farmer in _dbContext.Farmers
                                        where farmer.PhoneNumber == farmerDto.PhoneNumber
                                        select farmer)
                                        .FirstOrDefaultAsync();

            if (existingFarmer != null)
            {
                return Echos.BadRequest("Farmer already exists.");
            }

            // Create and save Address
            var newAddress = new Address
            {
                Street = farmerDto.Street,
                City = farmerDto.City,
                State = farmerDto.State,
                ZipCode = farmerDto.ZipCode
            };
            _dbContext.Addresses.Add(newAddress);
            await _dbContext.SaveChangesAsync();

            // Create and save Farmer
            var newFarmer = new Farmer
            {
                Name = farmerDto.Name, // Set the Name property
                PanNumber = farmerDto.PanNumber,
                RegistrationDate = farmerDto.RegistrationDate,
                Email = farmerDto.Email,
                PhoneNumber = farmerDto.PhoneNumber,
                BankAccountNumber = farmerDto.BankAccountNumber,
                AadharNumber = farmerDto.AadharNumber,
                AddressId = newAddress.Id, // Link to Address
                Address = newAddress
                //ImageId = uploadImage?.Id, // Link to UploadImage (optional)
                //UploadImage = uploadImage // Optional if you are using image upload
            };
            _dbContext.Farmers.Add(newFarmer);
            await _dbContext.SaveChangesAsync();

            return Echos.Ok("Farmer created successfully.");
        }


        // Handle file upload
        //UploadImage? uploadImage = null;
        //if (farmerDto.File?.Length > 0)
        //{
        //    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages");
        //    Directory.CreateDirectory(uploadsFolder);

        //    var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(farmerDto.File.FileName)}";
        //    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //    // Save file to server
        //    await using var stream = new FileStream(filePath, FileMode.Create);
        //    await farmerDto.File.CopyToAsync(stream);

        // Convert file to byte array
        //byte[] imageData;
        //await using (var ms = new MemoryStream())
        //{
        //    await farmerDto.File.CopyToAsync(ms);
        //    imageData = ms.ToArray();
        //}

        // Create UploadImage record
        //uploadImage = new UploadImage
        //{
        //    ImageName = farmerDto.File.FileName,
        //    ImageData = imageData,
        //    Url = filePath
        //};
        //_dbContext.UploadImages.Add(uploadImage);
        //await _dbContext.SaveChangesAsync(); // Save to generate ImageId
    }

    // Create and save Farmer



}



