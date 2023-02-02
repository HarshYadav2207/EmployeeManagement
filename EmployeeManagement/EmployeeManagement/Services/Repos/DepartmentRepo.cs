using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Repos
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        private readonly dbContext _dbContext;
        private IGenericRepo<Department> _repo;
        public DepartmentRepo(dbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _repo = new GenericRepo<Department>(dbContext);
        }

        public Department Add(Department addRequest)
        {
            var department = new Department()
            {
                DepartmentId = addRequest.DepartmentId,
                DepartmentName = addRequest.DepartmentName,
            };
            _dbContext.departments.Add(department);
            return department;
        }

        public Department Update(int Id, Department updateRequest)
        {
            var department = _dbContext.departments.Find(Id);
            department.DepartmentName = updateRequest.DepartmentName;
            department.DepartmentName = updateRequest.DepartmentName;
            _dbContext.departments.Update(department);
            return department;
        }
    }
}
