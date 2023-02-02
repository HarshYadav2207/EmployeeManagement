using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;


namespace EmployeeManagement.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
