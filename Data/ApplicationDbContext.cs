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


            //  between Farmer and Crop
            modelBuilder.Entity<Farmer>()
                .HasMany(f => f.Crops)
                .WithOne(c => c.Farmer)
                .HasForeignKey(c => c.FarmerId);

            modelBuilder.Entity<Farmer>()
             .HasMany(f => f.Cattles)
             .WithOne(c => c.Farmer)
             .HasForeignKey(c => c.FarmerId);  // This defines the foreign key in the Cattle table
        }
            // Fluent API configuration for the Farmer-Address one-to-many relationship
        //    modelBuilder.Entity<Farmer>()
        //   .HasMany(f => f.Addresses)
        //   .WithOne(a => a.Farmer)
        //   .HasForeignKey(a => a.FarmerId);
        //}

        // DbSet properties to represent tables in the database
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cattle> Cattles { get; set; }
        public DbSet<Crop> Crops { get; set; }
    }
}


