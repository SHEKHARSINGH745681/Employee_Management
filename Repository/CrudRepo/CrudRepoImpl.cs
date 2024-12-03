
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Models.Entity;
using EmployeeAdminPortal.RTO;
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

       

        public async Task<Farmer> CreateFarmerAsync(Farmer farmer)
        {
            if (farmer == null || farmer.Address == null)
            {
                throw new ArgumentNullException("Farmer and Address data must be provided.");
            }

            _dbContext.Add(farmer.Address);
            await _dbContext.SaveChangesAsync();

            farmer.AddressId = farmer.Address.Id;

            _dbContext.Add(farmer);
            await _dbContext.SaveChangesAsync();

            return farmer;
        }

        public async Task<IEnumerable<FarmerRTO>> GetFarmerAsync()
        {
            var farmers = await _dbContext.Set<Farmer>() 
                .Include(f => f.Address) 
                .Select(f => new FarmerRTO
                {
                    FirstName = f.FirstName,
                    LastName = f.LastName,
                    Address = new RTO.AddressRTO
                    {
                        Village = f.Address.Village,
                        City = f.Address.City,
                        PostalCode = f.Address.PostalCode
                    }
                })
                .ToListAsync();



            return farmers;
        }


    }
}
