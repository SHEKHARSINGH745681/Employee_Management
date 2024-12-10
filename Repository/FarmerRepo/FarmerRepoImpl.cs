﻿
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
            //.Include(f => f.Address)

            .Select(f => new FarmerRTO
            {
                name = f.Name,
                email = f.Email,
                phoneNumber = f.PhoneNumber,
                //Street = f.Address.Street,
                //City = f.Address.City,
                //State = f.Address.State,
                //ZipCode = f.Address.ZipCode,

            })
            .ToListAsync();
            return farmers;
        }

        public async Task<ActionResult<Echos>> AddFarmer(FarmerDTO farmerDto)
        {
            if (farmerDto == null || farmerDto.file == null || farmerDto.file.Length == 0)
            {
                return Echos.BadRequest("Invalid farmer data or file.");
            }

            byte[] imageData;
            using (var memoryStream = new MemoryStream())
            {
                await farmerDto.file.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }

            var uploadImageEntity = new UploadImage
            { 
                ImageData = imageData,
                Url = $"/uploads/{farmerDto.file.FileName}" 
            };

            _dbContext.UploadImages.Add(uploadImageEntity);
            await _dbContext.SaveChangesAsync();


            var newAddress = new Address
            {
                Street = farmerDto.Street,
                City = farmerDto.City,
                State = farmerDto.State,
                ZipCode = farmerDto.ZipCode
            };
            _dbContext.Addresses.Add(newAddress);
            await _dbContext.SaveChangesAsync();


            var newCrop = new Crop
            {
                CropName = farmerDto.CropName,
                Season = farmerDto.Season,
                Quantity= farmerDto.Quantity,
                HarvestDate = farmerDto.HarvestDate
   
            };
            _dbContext.Crops.Add(newCrop);
            await _dbContext.SaveChangesAsync();

            var newFarmer = new Farmer
            {
                Name = farmerDto.Name,
                PanNumber = farmerDto.PanNumber,
                RegistrationDate = farmerDto.RegistrationDate,
                Email = farmerDto.Email,
                PhoneNumber = farmerDto.PhoneNumber,
                BankAccountNumber = farmerDto.BankAccountNumber,
                AadharNumber = farmerDto.AadharNumber,
                ImageId = uploadImageEntity.Id,
                AddressId = newAddress.Id,
                CropId = newCrop.Id
                
            };

            _dbContext.Farmers.Add(newFarmer);
            await _dbContext.SaveChangesAsync();

            return Echos.Ok("Farmer created successfully.");
        }

    }
}


   








