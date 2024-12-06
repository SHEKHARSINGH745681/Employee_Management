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
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Department> Departments { get; set; }
       // public DbSet<Dispatch> Dispatchs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Farmer>()
                .HasOne(f => f.Address)
                .WithOne(a => a.Farmer)
                .HasForeignKey<Address>(f => f.FarmerId);

            modelBuilder.Entity<Farmer>()
                .HasMany(f => f.Crops) 
                .WithOne(c => c.Farmer) 
                .HasForeignKey(c => c.FarmerId); 




        }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Crop> Crops { get; set; }
    }
}


