using Catalog.Domain.SeedWork;
using Catalog.Infrastructure.DataContext;
using Catalog.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly CatalogDbContext _catalogDbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
            _dbSet = _catalogDbContext.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> All()
        {
            return  await _dbSet.ToListAsync();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<long> LongCountAsync()
        {
            return await _dbSet.LongCountAsync();
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll(int pageSize, int pageIndex, string orderBy)
        {
            var itemsOnPage = await _dbSet.OrderQuery<T>(orderBy)
                .Skip(pageSize * pageIndex)
                .Take(pageSize).ToListAsync();
            return itemsOnPage;
        }
    }
}
