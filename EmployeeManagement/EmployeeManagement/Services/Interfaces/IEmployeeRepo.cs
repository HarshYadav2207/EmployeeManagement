using EmployeeManagement.Models;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeRepo : IGenericRepo<Employee>
    {
        Employee Add(Employee addRequest);
        Employee UpdateEmployee(int Id,Employee updateRequest);
    }
}