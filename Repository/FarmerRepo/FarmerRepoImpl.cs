
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
                .Include(f => f.Crops)
                .Select(f => new FarmerRTO
                {
                    name = f.Name,
                    email = f.Email,
                    phoneNumber = f.PhoneNumber,
                    Street = f.Address.Street,
                    City = f.Address.City,
                    State = f.Address.State,
                    ZipCode = f.Address.ZipCode,
                    CropName = f.Crops.FirstOrDefault().CropName,
                    Season = f.Crops.FirstOrDefault().Season,
                    HarvestDate = f.Crops.FirstOrDefault().HarvestDate
                })
                .ToListAsync();
            return farmers;
        }

        public async Task<ActionResult<Echos>> AddFarmer(FarmerDTO farmerDto)
        {
            //var existingFarmer = await _dbContext.Farmers
            //    .FirstOrDefaultAsync(f => f.PhoneNumber == farmerDto.PhoneNumber);
            //if (existingFarmer != null)
            //{
            //    return Echos.BadRequest("Farmer already exists.");
            //}

            var newCrop = new Crop
            {
                CropName = farmerDto.CropName,
                Season = farmerDto.Season,
                Quantity = farmerDto.Quantity,
                HarvestDate = farmerDto.HarvestDate
            };

            _dbContext.Add(newCrop);

            var newAddress = new Address
            {
                Street = farmerDto.Street,
                City = farmerDto.City,
                State = farmerDto.State,
                ZipCode = farmerDto.ZipCode
            };

            _dbContext.Add(newAddress);

            var newFarmer = new Farmer
            {
                Name = farmerDto.Name,
                PanNumber = farmerDto.PanNumber,
                RegistrationDate = farmerDto.RegistrationDate,
                Email = farmerDto.Email,
                PhoneNumber = farmerDto.PhoneNumber,
                BankAccountNumber = farmerDto.BankAccountNumber,
                AadharNumber = farmerDto.AadharNumber,
                AddressId = newAddress.Id,
                Address = newAddress,
                Crops = new List<Crop> { newCrop }
            };

            _dbContext.Add(newFarmer);

            await _dbContext.SaveChangesAsync();

            return Echos.Ok($"Farmer Created SucessFullly");
        }

    }
}



