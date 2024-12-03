using EmployeeAdminPortal.Moddels.Entities;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dispatch> Dispatchs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between Department and Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);


            //  between Farmer and Address
            modelBuilder.Entity<Farmer>()
                .HasOne(f => f.Address)
                .WithOne()
                .HasForeignKey<Farmer>(f => f.AddressId);
        }




        //CRUD CONTROLLER
        public DbSet<Farmer> farmers { get; set; }
        public DbSet<Address> Addresses { get; set; }


    }


}
