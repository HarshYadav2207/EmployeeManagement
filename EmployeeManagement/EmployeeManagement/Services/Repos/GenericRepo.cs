using EmployeeManagement.Data;
using EmployeeManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Services.Repos
{
    public class GenericRepo<_class> : IGenericRepo<_class> where _class : class
    {
        private readonly dbContext _dbContext;
        private DbSet<_class> _dbSet;
        public GenericRepo(dbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<_class>();
        }

        public List<_class> GetAll()
        {
            return _dbSet.ToList();
            
        }

        public _class GetById(Expression<Func<_class,bool>> predicate)
        {
            var data = _dbSet.Where(predicate).FirstOrDefault();
            return data;
        }

        public void delete(_class entity)
        {
               _dbSet.Remove(entity);
        }
    }
}
