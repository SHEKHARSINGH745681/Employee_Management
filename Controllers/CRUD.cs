using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.DTO;
using EmployeeAdminPortal.Models.Entity;
using EmployeeAdminPortal.Repository.CrudRepo;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllFarmer()
        {
            var farmers = await _crudRepo.GetFarmerAsync();
            return Ok(farmers);
        }


        [HttpPost]
        [Route("/farmer")]
        public async Task<IActionResult> CreateFarmer([FromBody] FarmerDTO farmerDto)
        {
            var farmer = new Farmer
            {
                FirstName = farmerDto.FirstName,
                LastName = farmerDto.LastName,
                Description = farmerDto.Description,
                Address = new Address
                {
                    Village = farmerDto.Address.Village,
                    City = farmerDto.Address.City,
                    PostalCode = farmerDto.Address.PostalCode,
                    Country = farmerDto.Address.Country,
                    Phone = farmerDto.Address.Phone
                }
            };

            var createdFarmer = await _crudRepo.CreateFarmerAsync(farmer);
            return Ok(new { message = "Farmer Create SucessFully" });

        }

    }
}
