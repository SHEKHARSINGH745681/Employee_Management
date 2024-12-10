using EmployeeAdminPortal.Moddels.Entities;
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
            //Image
            modelBuilder.Entity<Farmer>()
                .HasOne(f => f.UploadImage)      
                .WithOne()          
                .HasForeignKey<UploadImage>(u => u.Id);
            //address
            modelBuilder.Entity<Farmer>()
               .HasOne(f => f.Address)
               .WithOne()
               .HasForeignKey<Address>(u => u.Id);
            //Crop
            modelBuilder.Entity<Farmer>()
              .HasOne(f => f.Crop)
              .WithOne()
              .HasForeignKey<Crop>(u => u.Id);
            //Cattle
            modelBuilder.Entity<Farmer>()
              .HasOne(f => f.Cattle)
              .WithOne()
              .HasForeignKey<Cattle>(u => u.Id);

        }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<UploadImage> UploadImages { get; set; }

    }
}


