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

    [Route("Api/[Controller]")]
    [ApiController]
    public class CRUD : ControllerBase
    {
        private readonly CrudRepo _crudRepo;

        public CRUD(CrudRepo crudRepo, ApplicationDbContext dbContext)
        {
            _crudRepo = crudRepo;
        }

        [HttpGet]
        [Route("/farmer")]
        public async Task<ActionResult<Echos>> GetAllFarmer()
        {
            var farmers = await _crudRepo.GetFarmerAsync();
            return Echos.Ok(farmers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FarmerRTO?>> GetById(int id)
        {
            var farmer = await _crudRepo.GetById(id);
            return Echos.OkIfNotNull(farmer);
            
        }

 
        [HttpPost]
        [Route("/farmer")]
        public async Task<ActionResult<Echos>> AddFarmer([FromBody] FarmerDTO farmerDto)
        {
            var result = await _crudRepo.AddFarmer(farmerDto);
            return result;
        }

    }
}