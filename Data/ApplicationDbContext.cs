using EmployeeAdminPortal.Moddels.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbContext : DbContext

    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{

        //}
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }


        public DbSet<Models.Entities.Department> Departments { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Entities.Department>()
                 .ToTable("Departments")
                .HasKey(d => d.Id); // Specify the primary key
        }


    }


}
