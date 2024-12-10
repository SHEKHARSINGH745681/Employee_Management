using System;
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
            //modelBuilder.Entity<Employee>()
            //    .HasOne(e => e.Department)
            //    .WithMany(d => d.Employees)
            //    .HasForeignKey(e => e.DepartmentId);


            modelBuilder.Entity<Farmer>()
                .HasOne(f => f.Image) // Farmer has one UploadImage
                .WithMany() // UploadImage can have many Farmers
                .HasForeignKey(f => f.ImageId) // Foreign key in Farmer entity
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete

            
            modelBuilder.Entity<UploadImage>()
                .HasKey(ui => ui.Id); // Primary key



            //address
            modelBuilder.Entity<Farmer>()
                .HasOne(f => f.Address)
                .WithMany()
                .HasForeignKey(f => f.AddressId);



            //Crop
            modelBuilder.Entity<Farmer>()
              .HasOne(f => f.Crop)
              .WithMany()
              .HasForeignKey(f => f.CropId);


        }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<UploadImage> UploadImages { get; set; }

    }
}


