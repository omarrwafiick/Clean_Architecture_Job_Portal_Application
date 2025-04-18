   
namespace ApplicationLayer.Interfaces
{
    public interface ICreateRepository<T> where T : class 
    { 
        Task<bool> CreateAsync(T entity);
    }
}
