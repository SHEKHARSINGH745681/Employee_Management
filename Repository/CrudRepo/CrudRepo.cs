
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Models.Entity;
using EmployeeAdminPortal.RTO;

namespace EmployeeAdminPortal.Repository.CrudRepo
{
    public interface CrudRepo
    {

        Task<Farmer> CreateFarmerAsync(Farmer farmer);

        Task<IEnumerable<FarmerRTO>> GetFarmerAsync();
    }
}
