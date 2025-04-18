
using ApplicationLayer.Interfaces;
using InfrastructureLayer.Data; 

namespace InfrastructureLayer.Implementations.Repositories
{
    public class UpdateRepository<T> : IUpdateRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            await Task.Run(() => _dbContext.Set<T>().Update(entity));
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0) return true;
            return false;
        }

    }
}
