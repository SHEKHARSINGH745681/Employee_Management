using EmployeeAdminPortal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{

    //localhost:7028/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelExportController : ControllerBase
    {
        private readonly EmpRepo _empRepo;

        // Constructor for dependency injection
        public ExcelExportController(EmpRepo empRepo)
        {
            _empRepo = empRepo;
        }



        //[HttpGet("export")]
        //public async Task<IActionResult> ExportEmployeesToExcel()
        //{
        //    // Delegate the Excel generation to the repository
        //    var fileContent = await _empRepo.ExportEmployeesToExcelAsync();

        //    // Return the Excel file as a downloadable response
        //    return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
        //}
    }
}

