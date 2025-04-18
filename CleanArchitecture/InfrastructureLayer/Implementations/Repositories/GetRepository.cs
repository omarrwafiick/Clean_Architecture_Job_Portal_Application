using ApplicationLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions; 

namespace InfrastructureLayer.Implementations.Repositories
{
    public class GetRepository<T> : IGetRepository<T> where T : class, IBaseEntity
    {
        private readonly ApplicationDbContext _context;
        public GetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> Get(Guid id) => await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

        public async Task<T> Get(Expression<Func<T, bool>> condition) 
            => await _context.Set<T>().AsNoTracking().Where(condition).SingleOrDefaultAsync();
        public async Task<T> Get(Guid id,Expression<Func<T, object>> include)
            => await _context.Set<T>().AsNoTracking().Include(include).SingleOrDefaultAsync(x => x.Id == id);
    }
}
