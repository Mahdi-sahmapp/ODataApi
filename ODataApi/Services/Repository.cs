using Microsoft.EntityFrameworkCore;
using ODataApi.Models;

namespace ODataApi.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ODataDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(ODataDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Add(T Entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(Entity);
            await _context.SaveChangesAsync();
            return await Task.FromResult(Entity);
        }

        public async Task<bool> Delete(T Entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(Entity);
            await _context.SaveChangesAsync();
            return true;
        }

        IQueryable<T> IRepository<T>.GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<T> Update(T Entity, int Id, CancellationToken cancellationToken)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await Task.FromResult(Entity);
        }

        public async Task<T?> GetById(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FindAsync(new object[] { Id }, cancellationToken);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
