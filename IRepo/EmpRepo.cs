using System;
using EmployeeAdminPortal.Moddels.Entities;

namespace EmployeeAdminPortal.Repository
{
    public interface EmpRepo
    {
        // Retrieves all employees asynchronously
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        // Retrieves an employee by ID asynchronously
        Task<Employee> GetEmployeeByIdAsync(int id);

        // Adds a new employee asynchronously
        Task<Employee> AddEmployeeAsync(Employee employee);

        // Deletes an employee by ID asynchronously
        Task<bool> DeleteEmployeeAsync(int id);
        Task<byte[]> ExportEmployeesToExcelAsync();
    }
}


