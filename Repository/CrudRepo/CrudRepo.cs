
using EmployeeAdminPortal.Models.Entity;

namespace EmployeeAdminPortal.Repository.CrudRepo
{
    public interface CrudRepo
    {
        Task<IEnumerable<Farmer>> GetFarmerAsync();
        Task<Farmer> CreateFarmerAsync(Farmer farmer);
    }
}
