using ApplicationLayer.Interfaces;
using InfrastructureLayer.Data; 

namespace InfrastructureLayer.Implementations.Repositories
{
    public class CreateRepository<T> : ICreateRepository<T> where T : class 
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        } 

        public async Task<bool> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0) return true;
            return false;
        }

    }
}
