
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Echo;
using EmployeeAdminPortal.Models.Entity;
using EmployeeAdminPortal.RTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                .Include(f => f.Crops)
                .Include(f => f.Cattles)
                .Select(f => new FarmerRTO
                {
                    name = f.name,
                    email = f.email,
                    isActive = f.isActive,
                    phoneNumber = f.phoneNumber
                })
                .ToListAsync();
            return farmers;
        }

        //public async Task<FarmerRTO?> GetById(int id)
        //{
        //    var farmer = await _dbContext.Set<Farmer>()
        //        .Include(f => f.Address)
        //        .Where(f => f.name == name)
        //        .Select(f => new FarmerRTO
        //        {
        //            FirstName = f.FirstName,
        //            LastName = f.LastName,
        //            Village = f.Address.Village,
        //            City = f.Address.City,
        //            PostalCode = f.Address.PostalCode
        //        })
        //        .FirstOrDefaultAsync();

        //    return farmer;
        //}

        public async Task<ActionResult<Echos>> AddFarmer(FarmerDTO farmerDto)
        {
            var existingFarmer = await _dbContext.Farmers
                .FirstOrDefaultAsync(f => f.phoneNumber == farmerDto.phoneNumber);

            if (existingFarmer != null)
            {
                return Echos.BadRequest($"Farmer already exists.");
            }

            var newCrop = new Crop
            {
                CropName = farmerDto.Crop.CropName,
                Season = farmerDto.Crop.Season,
                Quantity = farmerDto.Crop.Quantity,
                HarvestDate = farmerDto.Crop.HarvestDate
                
            };

            var newCattale = new Cattle
            {
                Breed = farmerDto.Cattle.Breed,
                Age = farmerDto.Cattle.Age,
                HealthStatus = farmerDto.Cattle.HealthStatus
            };

            var newFarmer = new Farmer
            {
                name = farmerDto.name,
                panNumber = farmerDto.panNumber,
                email = farmerDto.email,
                bankAccountNumber = farmerDto.bankAccountNumber,
                aadharNumber = farmerDto.aadharNumber,
                isActive = farmerDto.isActive,
            };

            // Add all entities and save in a single transaction
            _dbContext.AddRange(newCrop, newCattale, newFarmer);
            await _dbContext.SaveChangesAsync();

            return Echos.Ok(newFarmer);
        }

    }
}



