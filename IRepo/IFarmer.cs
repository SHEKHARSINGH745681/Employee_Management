
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Echo;
using EmployeeAdminPortal.Models.Entity;
using EmployeeAdminPortal.RTO;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Repository.CrudRepo
{
    public interface IFarmer
    {
        Task<ActionResult<Echos>> AddFarmer(FarmerDTO farmerDto);
     
        Task<IEnumerable<FarmerRTO>> GetFarmerAsync();
    }
}
