using System.Linq.Expressions;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IGenericRepo<_class> where _class : class
    {
        List<_class> GetAll();
        _class GetById(Expression<Func<_class, bool>> predicate);
        void delete(_class entity);
    }
}