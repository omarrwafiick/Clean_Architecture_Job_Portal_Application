

using ApplicationLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Implementations.Repositories
{
    public class DeleteRepository<T> : IDeleteRepository<T> where T : class, IBaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            await Task.Run(() => _dbContext.Set<T>().Remove(entity));
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0) return true;
            return false;
        }
    }
}
