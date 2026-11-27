using HealthCareSystem.DAL.Data;
using HealthCareSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCareSystem.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbContext.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
            => await _dbContext.Set<T>().FindAsync(id);

        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            var exists = await _dbContext.Set<T>().AsNoTracking().AnyAsync(e => e.Id == entity.Id);

            if (!exists)
                return false;

            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is null)
                return false;

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}