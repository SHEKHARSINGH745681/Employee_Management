using EmployeeAdminPortal.Moddels.Entities;
using System.Text.Json.Serialization;

namespace EmployeeAdminPortal.Models
{
    public class Department
    {

        
        public int Id { get; set; }
        public string DepartmentName { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
