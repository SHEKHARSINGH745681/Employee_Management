using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Models.Entity;
using EmployeeAdminPortal.Repository.CrudRepo;
using Microsoft.AspNetCore.Mvc;
using EmployeeAdminPortal.Echo;
using EmployeeAdminPortal.RTO;
using EmployeeAdminPortal.IRepo;

namespace EmployeeAdminPortal.Controllers
{

    [Route("Api/[controller]")]
    [ApiController]
    public class Farmer_Controller : ControllerBase
    {
        private readonly IFarmer _Ifarmer;

        public Farmer_Controller(IFarmer _Ifarmer, ApplicationDbContext dbContext)
        {
            this._Ifarmer = _Ifarmer;
        }

        [HttpGet]
        [Route("/Getfarmer")]
        public async Task<ActionResult<Echos>> GetAllFarmer()
        {
            var farmers = await _Ifarmer.GetFarmerAsync();

            return Echos.Ok(farmers);
        }
 
        [HttpPost]
        [Route("/Addfarmer")]
        public async Task<ActionResult<Echos>> AddFarmer([FromForm] FarmerDTO farmerDto)
        {
            var result = await _Ifarmer.AddFarmer(farmerDto);
            return result;
        }

        
    }
}