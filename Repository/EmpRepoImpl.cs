using System;
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Moddels.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Repository
{
    public class RepositoryImpl : EmpRepo
    {
        private readonly ApplicationDbContext _dbContext;

        // Constructor for injecting the database context
        public RepositoryImpl(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Retrieves all employees from the database
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        // Retrieves a single employee by ID
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        // Adds a new employee to the database
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }

        // Deletes an employee by ID
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}