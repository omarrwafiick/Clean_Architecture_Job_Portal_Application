
using ApplicationLayer.Interfaces;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InfrastructureLayer.Implementations.Repositories
{
    public class GetAllRepository<T> : IGetAllRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GetAllRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().AsNoTracking().ToListAsync();
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> condition)
            => await _context.Set<T>().AsNoTracking().Where(condition).ToListAsync();
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, object>> include)
            => await _context.Set<T>().AsNoTracking().Include(include).ToListAsync();
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, object>> include1, Expression<Func<T, object>> include2)
            => await _context.Set<T>().AsNoTracking().Include(include1).Include(include2).ToListAsync();
    }
}
