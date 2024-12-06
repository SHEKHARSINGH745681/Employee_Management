using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAdminPortal.Models.Entity
{
    public class Cattle
    {
        [Key]
        public int Id { get; set; }
        public string ? Breed { get; set; }
        public int Age { get; set; }
        public string ? HealthStatus { get; set; }
        //public int FarmerId { get; set; }
        //public Farmer? Farmer { get; set; } 





    }
}
