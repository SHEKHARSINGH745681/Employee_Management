
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Echo;
using EmployeeAdminPortal.Models.Entity;
using EmployeeAdminPortal.RTO;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Repository.CrudRepo
{
    public interface CrudRepo
    {
        Task<ActionResult<Echos>> AddFarmer(FarmerDTO farmerDto);
      //  Task CreateFarmerAsync(Farmer farmer);
        Task<FarmerRTO?> GetById(int id);
        Task<IEnumerable<FarmerRTO>> GetFarmerAsync();
    }
}
