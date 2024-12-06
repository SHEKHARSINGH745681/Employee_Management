
using System.Text.Json.Serialization;

namespace EmployeeAdminPortal.Models.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string ?Street { get; set; }
        public string ?City { get; set; }
        public string ?State { get; set; }
        public string ?ZipCode { get; set; }
        public int FarmerId { get; set; }

        [JsonIgnore]
        public Farmer ?Farmer { get; set; } // Navigation Property to Farmer
    }
}

