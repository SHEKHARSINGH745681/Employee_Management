using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Repository;
using EmployeeAdminPortal.Moddels.Entities;
using Microsoft.AspNetCore.Mvc;
using EmployeeAdminPortal.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeAdminPortal.Controllers
{

    [Route("Api/[Controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepRepo _depRepo;

        public DepartmentController(IDepRepo depRepo)
        {
            _depRepo = depRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _depRepo.GetDepartmentsAsync();
            return Ok(departments);
        }

        [HttpPost]
        public async Task<IActionResult>AddDepartments(Department department)
        {
            var newEmployee = await _depRepo.AddDepartments(department);
            return Ok(newEmployee);
        }

           
        
    }

}

