using EmployeeAdminPortal.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;


namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Department> Departments { get; set; }
        // public DbSet<Dispatch> Dispatchs { get; set; }

        modelBuilder.Entity<Farmer>()
                .HasOne(f => f.Image) // Farmer has one UploadImage
                .WithMany() // UploadImage can have many Farmers
                .HasForeignKey(f => f.ImageId); // Foreign key in Farmer entity

            
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


