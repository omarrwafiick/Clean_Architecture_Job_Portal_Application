 
namespace ApplicationLayer.Interfaces
{
    public interface IUpdateRepository<T> where T : class
    {
        Task<bool> UpdateAsync(T entity);
    }
}
