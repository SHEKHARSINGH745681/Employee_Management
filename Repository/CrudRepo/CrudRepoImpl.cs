
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Models.Entity;
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

        public async Task<IEnumerable<Farmer>> GetFarmerAsync()
        {
            //var farmers = await _dbContext.farmers.Include(f => f.Address).ToListAsync();
            //public async Task<IEnumerable<FarmerDTO>> GetFarmerAsync()
            //{
                var farmers = await _dbContext.Farmers
                    .Include(f => f.Address) // Ensure the Address navigation property is included
                    .Select(f => new FarmerDTO // Project Farmer entity to FarmerDTO
                    {
                        FirstName = f.FirstName,
                        LastName = f.LastName,
                        Address = new AddressDTO
                        {
                            Village = f.Address.Village,
                            City = f.Address.City,
                            PostalCode = f.Address.PostalCode
                            // Uncomment and include other properties as needed
                            // Country = f.Address.Country,
                            // Phone = f.Address.Phone
                        }
                    })
                    .ToListAsync();

                return farmers;
            }

            return farmers;
        }

    }
}
