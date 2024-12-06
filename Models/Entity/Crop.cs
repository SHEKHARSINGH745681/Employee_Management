using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models.Entity
{
	public class Crop
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ?CropName { get; set; }

        public string ?Season { get; set; }

        public double Quantity { get; set; }

        public string ?HarvestDate { get; set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; } = null!;


    }
}


 