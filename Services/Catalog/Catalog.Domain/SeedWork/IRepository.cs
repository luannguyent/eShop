using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.SeedWork
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(T entity);

        Task<long> LongCountAsync();

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAll(int pageSize, int pageIndex, string orderBy);
    }
}
