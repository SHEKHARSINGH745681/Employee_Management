namespace EmployeeAdminPortal.Models
{
    public class Dispatch
    {
        public int Id { get; set; } 
        public string? Company { get; set; } 
        public string? Branch { get; set; }
        public string? Fedration { get; set; }
        public string? FPC { get; set; }
        public string? DispatchDate { get; set; }
        public string? DispatchStatus { get; set; }
        public string? TruckNumber { get; set; }
        public string? BagCount { get; set; }
        public string? DriverName { get; set; }
        public string? DriverNumber { get; set; }
        public decimal NetWeight { get; set; }
    }
}
