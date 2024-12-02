using EmployeeAdminPortal.IRepo;
using EmployeeAdminPortal.Moddels.Entities;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        private readonly IDispatchRepo _idispatchRepo;

        public DispatchController(IDispatchRepo idispatchRepo)
        {
            _idispatchRepo = idispatchRepo;
        }

        [HttpGet("Export")]
        public async Task<IActionResult> ExportDispatchToExcel()
        {

            var fileContent = await _idispatchRepo.ExportDispatchToExcel();

            //  Jo downloadable response Hai
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Dispatch.xlsx");
        }

        [HttpPost("Add-Dispatch")]
        public async Task<IActionResult> AddDispatchAsync(Dispatch dispatch)
        {
            var newDispatch = await _idispatchRepo.AddDispatchAsync(dispatch);
            return Ok(newDispatch);
        }


    }
}

