using EmployeeManagement.Services.Repos;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepo _employeeRepo { get; }
        IDepartmentRepo _departmentRepo { get; }

        void save();
    }
}