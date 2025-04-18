 
using System.Linq.Expressions;

namespace ApplicationLayer.Interfaces
{
    public interface IGetRepository<T> where T : class, IBaseEntity
    {
        Task<T> Get(Guid id);
        Task<T> Get(Expression<Func<T,bool>> condition);
        Task<T> Get(Guid id, Expression<Func<T, object>> include);
    }
}
