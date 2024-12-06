
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
                .Include(f => f.Address)
                // .Include(f => f.Cattles)
                .Select(f => new FarmerRTO
                {
                    name = f.Name,
                    email = f.Email,
                   
                    phoneNumber = f.PhoneNumber
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
                CropName = farmerDto.Crop.CropName,
                Season = farmerDto.Crop.Season,
                Quantity = farmerDto.Crop.Quantity,
                HarvestDate = farmerDto.Crop.HarvestDate
            };

            _dbContext.Add(newCrop);

            var newAddress = new Address
            {
                Street = farmerDto.Address?.Street,
                City = farmerDto.Address?.City,
                State = farmerDto.Address?.State,
                ZipCode = farmerDto.Address?.ZipCode
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



