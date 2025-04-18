 
using System.Linq.Expressions;

namespace ApplicationLayer.Interfaces
{
    public interface IGetAllRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> condition);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, object>> include);
    }
}
