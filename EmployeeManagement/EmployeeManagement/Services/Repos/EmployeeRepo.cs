using EmployeeManagement.Data;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services.Repos
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {
        private readonly dbContext _dbContext;
        private IGenericRepo<Employee> _repo;
        public EmployeeRepo(dbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _repo = new GenericRepo<Employee>(dbContext);
        }

        public Employee Add(Employee addRequest)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = addRequest.Id,
                    Name = addRequest.Name,
                    salary = addRequest.salary,
                    DepartmentId = addRequest.DepartmentId,
                    designation = addRequest.designation,
                };
                _dbContext.employees.Add(employee);
                return employee;
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        public Employee UpdateEmployee(int Id,Employee updateRequest)
        {
            try
            {
                var employee = _dbContext.employees.Find(Id);
                employee.Name = updateRequest.Name;
                employee.salary = updateRequest.salary;
                employee.DepartmentId = updateRequest.DepartmentId;
                employee.designation = updateRequest.designation;
                return employee;
            }
            catch (Exception e)
            {

                throw;
            }
          
        }
    }
}
