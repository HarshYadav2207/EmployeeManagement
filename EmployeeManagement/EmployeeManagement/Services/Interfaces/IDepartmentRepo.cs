using EmployeeManagement.Models;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IDepartmentRepo : IGenericRepo<Department>
    {
        Department Add(Department addRequest);
        Department Update(int Id, Department updateRequest);
    }
}