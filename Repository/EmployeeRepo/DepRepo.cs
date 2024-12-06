using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Moddels.Entities;
using EmployeeAdminPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Repository
   {
        public class DepRepo : IDepRepo
        {
            private readonly ApplicationDbContext _context;

            public DepRepo(ApplicationDbContext context)
            {
                _context = context;
            }

        //public async Task<Department> AddDepartments(Department department)
        //{
        //    _context.Departments.Add(department);
        //    await _context.SaveChangesAsync();
        //    return department;
        //}

       

        //public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        //    {
        //        return await _context.Departments.ToListAsync();
        //    }
        }
    }

