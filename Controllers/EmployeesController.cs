using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Moddels;
using EmployeeAdminPortal.Moddels.DepartmentDto;
using EmployeeAdminPortal.Moddels.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EmployeeAdminPortal.Controllers
{
    //localhost:7028/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(dbContext.Employees.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }



        //find by List (employee and department)
        [HttpGet("list")] 
        public IActionResult GetEmployeeListById()
        {
            var employeeList = dbContext.Employees
                .Include(e => e.Department) 
                .ToList();


            return Ok(employeeList);
        }

        [HttpGet("list/{id}")]
        public IActionResult GetEmployeesById(int id)
        {
            var employee = dbContext.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }



        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {

            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
                Dep_Id = addEmployeeDto.Dep_Id,
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }

        //Department
        [HttpPost]
        [Route("department")]
        public IActionResult AddDepartment(AddDepartment addDepartment)
        {
            
            var departmentEntity = new Models.Entities.Department() 
            {
                Address = addDepartment.Address,
                BloodGroup = addDepartment.BloodGroup,
                Position = addDepartment.Position,
                Experience = addDepartment.Experience,
            };

            // Add the new entity to the DbContext
            dbContext.Departments.Add(departmentEntity);

            // Save changes to the database
            dbContext.SaveChanges();

            // Return the created department entity as a response
            return Ok(new
            {
                Message = "Department created successfully!",
                Department = departmentEntity
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();

            return Ok(employee);


        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok(employee);
        }
    }
}
