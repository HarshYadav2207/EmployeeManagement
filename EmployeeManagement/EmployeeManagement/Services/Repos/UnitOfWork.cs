using EmployeeManagement.Data;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepo _employeeRepo { get; private set; }
        public IDepartmentRepo _departmentRepo { get; private set; }

        private readonly dbContext _dbContext;

        public UnitOfWork(dbContext dbContext)
        {
            _dbContext = dbContext;
            _employeeRepo = new EmployeeRepo(dbContext);
            _departmentRepo = new DepartmentRepo(dbContext);
        }

        public void save()
        {
             _dbContext.SaveChanges();
        }
    }
}
