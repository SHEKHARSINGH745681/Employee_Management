
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
    public class CrudRepoImpl : CrudRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public CrudRepoImpl(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        //public async Task<Farmer> CreateFarmerAsync(Farmer farmer)
        //{
        //    var existingfarmer = await _dbContext.Set<Farmer>()
        //        .FirstOrDefaultAsync(f => f.FirstName == farmer.FirstName);

        //    if (existingfarmer == null)
        //    {
        //         Echos.NotFound($"{existingfarmer}");
        //    }

        //    _dbContext.Add(farmer.Address);
        //    await _dbContext.SaveChangesAsync();

        //    farmer.AddressId = farmer.Address.Id;

        //    _dbContext.Add(farmer);
        //    await _dbContext.SaveChangesAsync();

        //    return farmer
        //}

        public async Task<IEnumerable<FarmerRTO>> GetFarmerAsync()
        {
            var farmers = await _dbContext.Set<Farmer>()
                .Include(f => f.Address)
                .Select(f => new FarmerRTO
                {
                    FirstName = f.FirstName,
                    LastName = f.LastName,
                    Village = f.Address.Village,
                    City = f.Address.City,
                    PostalCode = f.Address.PostalCode

                })
                .ToListAsync();
            return farmers;
        }

        public async Task<FarmerRTO?> GetById(int id)
        {
            var farmer = await _dbContext.Set<Farmer>()
                .Include(f => f.Address)
                .Where(f => f.Id == id)
                .Select(f => new FarmerRTO
                {
                    FirstName = f.FirstName,
                    LastName = f.LastName,
                    Village = f.Address.Village,
                    City = f.Address.City,
                    PostalCode = f.Address.PostalCode
                })
                .FirstOrDefaultAsync();

            return farmer;
        }

        public async Task<ActionResult<Echos>> AddFarmer(FarmerDTO farmerDto)
        {
            var existingfarmer = await _dbContext.farmers
                .FirstOrDefaultAsync(f => f.FirstName == farmerDto.FirstName);

            if (existingfarmer != null)
            {
                return Echos.BadRequest($"already exists");
            }

            var newAddress = new Address
            {
                Village = farmerDto.Address.Village,
                City = farmerDto.Address.City,
                PostalCode = farmerDto.Address.PostalCode,
                Country = farmerDto.Address.Country,
                Phone = farmerDto.Address.Phone
            };

            var newFarmer = new Farmer
            {
                FirstName = farmerDto.FirstName,
                LastName = farmerDto.LastName,
                Description = farmerDto.Description,
                Address = newAddress
            };

            _dbContext.Add(farmerDto.Address);
            await _dbContext.SaveChangesAsync();

            newFarmer.AddressId = newFarmer.Address.Id;


            _dbContext.Add(farmerDto);
            await _dbContext.SaveChangesAsync();

            return Echos.Ok(newFarmer);
        }
    }
}
    

