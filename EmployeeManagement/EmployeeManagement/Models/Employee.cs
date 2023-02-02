using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double salary { get; set; }
        public string designation { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
